using BCommerce.CommonService.API.Application.UnitOfWork;
using BCommerce.CommonService.API.Middlewares;
using BCommerce.CommonService.API.ProtoServices;
using BCommerce.DataAccess.Shared.Interfaces;
using BCommerce.DataAccess.Shared.Services;
using BCommerce.Shared.Handler;
using BCommerce.Shared.Middlewares;
using BCommerce.Shared.PipelineBehaviours;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.Grafana.Loki;
using Serilog.Sinks.Loki;
using StackExchange.Redis;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Configure Serilog with GrafanaLoki integration
    Logger logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.GrafanaLoki("http://localhost:3100")
        .WriteTo.LokiHttp(new NoAuthCredentials(builder.Configuration.GetConnectionString("Loki")))
        .CreateLogger();

    builder.Services.AddAutoMapper(typeof(MappingProfile));

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<AppDbContext>(opt =>
    {
        opt.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AppDbContext)));
    });

    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

    //builder.AddCustomRedis();
    builder.Services.AddGrpc();
    builder.Services.AddScoped<DbContext, AppDbContext>();
    builder.Services.AddScoped<IAuditQuery, AuditQuery>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IAuditLogService, AuditLogService>();
    builder.Services.AddScoped<ICacheService, CacheService>();
    builder.Services.AddScoped<CustomExceptionFilter>();
    builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));
    builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

    builder.Services.AddLogging(loggingBuilder =>
    {
        loggingBuilder.ClearProviders(); // Clear other logging providers
        loggingBuilder.AddSerilog(logger); // Add Serilog as the logger provider
    });

    builder.Host.UseSerilog(logger);

    builder.Services.AddSwaggerGen(option =>
    {
        option.AddSecurityDefinition(builder.Configuration.GetValue<string>("Swagger:Scheme"), new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Name = builder.Configuration.GetValue<string>("Swagger:Type"),
            Type = SecuritySchemeType.Http,
            BearerFormat = builder.Configuration.GetValue<string>("Swagger:BearerFormat"),
            Scheme = builder.Configuration.GetValue<string>("Swagger:Scheme")
        });

        option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id = builder.Configuration.GetValue<string>("Swagger:Scheme")
                }
            },
            Array.Empty<string>()
        }
    });

        option.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = builder.Configuration.GetValue<string>("Swagger:Version"),
            Title = builder.Configuration.GetValue<string>("Swagger:Title")
        });

    });

    builder.Services
              .AddAuthentication(option =>
              {
                  option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                  option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(options =>
              {
                  options.Authority = builder.Configuration.GetValue<string>("KeyCloak:AuthorityUrl");
                  options.SaveToken = true;
                  options.RequireHttpsMetadata = false;

                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = builder.Configuration.GetValue<string>("KeyCloak:AuthorityUrl")
                  };
              });

    //Redis Connection configurations
    //string redisConnectionString = builder.Configuration.GetConnectionString("Redis");
    //builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));

    ////builder.Services.AddSingleton<RespServer>(new MemoryCacheRedisServer());

    //builder.Services.AddDistributedMemoryCache();

    //builder.WebHost.ConfigureKestrel(options =>
    //{
    //    options.ListenLocalhost(7026);

    //    options.ConfigureEndpointDefaults(options =>
    //    {
    //        options.UseConnectionHandler<RedisConnectionMiddleware>();
    //    });
    //    //options.ListenLocalhost(7026, builder =>
    //    //{
    //    //    builder.UseConnectionHandler<RedisConnectionMiddleware>();
    //    //});
    //});

    builder.Services.AddStackExchangeRedisCache(options => {
        options.Configuration = builder.Configuration.GetConnectionString("Redis");
        options.InstanceName = "";
    });

    builder.Services.AddDaprClient();

    builder.Services.AddHttpClient();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMetricServer();
    app.UseSerilogRequestLogging();
    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseMiddleware<CommonAuditLogPrometheusMiddleware>();
    //app.UseConnectionHandler<RedisConnectionMiddleware>();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseCors("AllowAll");
    app.UseHttpsRedirection();
    app.MapControllers();

    app.UseHttpMetrics(options =>
    {
        options.AddCustomLabel("host", context => context.Request.Host.Host);
    });
    app.MapGrpcService<CountryServices>();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}