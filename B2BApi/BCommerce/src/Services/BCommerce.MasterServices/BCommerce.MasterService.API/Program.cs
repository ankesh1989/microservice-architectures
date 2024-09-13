using BCommerce.DataAccess.Shared.Interfaces;
using BCommerce.DataAccess.Shared.Services;
using BCommerce.MasterService.API.Application.UnitOfWork;
using BCommerce.MasterService.API.Helpers;
using BCommerce.MasterService.API.Middlewares;
using BCommerce.MasterService.API.Repositories;
using EventBus;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Prometheus;
using SupplierService = BCommerce.MasterService.API.ProtoServices.SupplierService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddControllers().AddDapr();

builder.Services.AddDaprClient();

//builder.Services.AddDaprClient(client =>
//{
//    client.UseHttpEndpoint("http://localhost:8080");
//    client.UseGrpcEndpoint("http://localhost:50001");
//    //client.UseRetry(retryCount: 3, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
//});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AppDbContext)));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddScoped<DbContext, AppDbContext>();
builder.Services.AddScoped<IAuditQuery, AuditQuery>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IEventBus, DaprEventBus>();
//builder.Services.AddScoped<UserSupplierAddIntegrationEventHandler>();
builder.Services.AddScoped<GetSupplierIntegrationEventHandler>();
//builder.Services.AddScoped<IDaprSupplierRepository, DaprSupplierRepository>();
//builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

//builder.Services.AddScoped<SupplierValidationService>();

//var serviceProvider = new ServiceCollection()
//          .AddDbContext<AppDbContext>(options =>
//          {
//              options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AppDbContext)));
//          })
//          .AddScoped<IUnitOfWork, UnitOfWork>()
//          .AddScoped<IEventBus, DaprEventBus>()
//          //.AddScoped<DaprClient, DaprEventBus>()
//          .BuildServiceProvider();
//////          .AddScoped<IUnitOfWork, UnitOfWork>()
//////          .AddScoped<ISupplierRepository, SupplierRepository>()
//////          .AddScoped<SupplierValidationService>()
//////          .BuildServiceProvider();

//////IUnitOfWork unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
//////IUnitOfWork unitOfWork = new UnitOfWork(AppDbContext);
//////ISupplierRepository repository = new SupplierRepository(unitOfWork);
//////SupplierValidationService validationService = new SupplierValidationService(repository);

//builder.Services.AddScoped<DaprEventBus>();

//IEventBus eventBus = serviceProvider.GetRequiredService<DaprEventBus>();

//AirlineValidatedEventPublisher airlineEvent = new AirlineValidatedEventPublisher("localhost");
//SupplierService supplierService = new SupplierService(airlineEvent); //new SupplierService(repository);

// Get an instance of the SupplierValidationService
//var supplierValidationService = serviceProvider.GetRequiredService<SupplierValidationService>();

builder.Services.AddSwaggerGen(option => {
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

//AirlineEventHandler eventHandler = new AirlineEventHandler("localhost");
////eventHandler.StartHandlingOrderEvents();
////eventHandler.CloseConnection();

//var repository = new SupplierRepository();
//var orderValidationService = new SupplierValidationService();
//orderValidationService.StartListening();

//builder.WebHost.ConfigureKestrel(options =>
//{
//    var httpPort = 8026;
//    var grpcPort = 50003;

//    options.Listen(IPAddress.Any, httpPort, listenOptions =>
//    {
//        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
//        listenOptions.UseHttps();
//    });

//    options.Listen(IPAddress.Any, grpcPort, listenOptions =>
//    {
//        listenOptions.Protocols = HttpProtocols.Http2;
//    });
//});

builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMetricServer();
//app.UseMiddleware<KeycloakAuthorizationMiddleware>();
app.UseMiddleware<CommonAuditLogPrometheusMiddleware>();

app.UseRouting();
app.UseCloudEvents();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");

app.MapGrpcService<SupplierService>();
app.UseHttpsRedirection();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapSubscribeHandler();
//    endpoints.MapControllers();
//});
app.MapControllers();
app.MapSubscribeHandler();

app.UseHttpMetrics(options =>
{
    options.AddCustomLabel("host", context => context.Request.Host.Host);
});
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

using var scope = app.Services.CreateScope();

var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

app.Run();