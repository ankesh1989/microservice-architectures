using BCommerce.AirlineService.API;
using BCommerce.AirlineService.API.Helpers;
using BCommerce.DataAccess.Shared.Interfaces;
using BCommerce.DataAccess.Shared.Services;
using EventBus;
using Google.Api;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using StackExchange.Redis;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Grpc.Net.Client;
using Microsoft.OpenApi.Models;
using Dapr.Extensions.Configuration;
using BCommerce.AirlineService.API.ProtoServices;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddDaprSecretStore(
//              "secretstore",
//              new DaprClientBuilder().Build());

builder.AddCustomHealthChecks();
builder.AddCustomApplicationServices();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers().AddDapr();

builder.Services.AddDaprClient();

//builder.Services.AddDaprClient(client =>
//{
//    client.UseHttpEndpoint("http://localhost:8080");
//    client.UseGrpcEndpoint("http://localhost:50001");
//});
builder.Services.AddActors(options =>
{
    options.Actors.RegisterActor<AirlineProcessActor>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
builder.Services.AddScoped<IEventBus, DaprEventBus>();
//builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.Configure<AirlineSettings>(builder.Configuration);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AppDbContext)));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//builder.AddCustomRedis();

builder.Services.AddScoped<DbContext, AppDbContext>();
builder.Services.AddScoped<IAuditQuery, AuditQuery>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();

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

//SupplierValidationService supplierValidationService = new SupplierValidationService();

//builder.Services.AddSingleton(typeof(AirlineCreatedEventPublisher)); // Add other dependencies if needed

//Redis Connection configurations
string redisConnectionString = builder.Configuration.GetConnectionString("Redis");
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));

//builder.Services.AddSingleton<AirlineCreatedEventPublisher>(provider =>
//{
//    // Retrieve configuration or hardcode the RabbitMQ host name
//    var hostName = builder.Configuration["RabbitMqSetting:HostAddress"];
//    return new AirlineCreatedEventPublisher(hostName);
//});

//builder.Services.AddMassTransit(busRegistrationConfigurator =>
//{
//    //busRegistrationConfigurator.AddScoped<AirlineCreatedEventPublisher>();
//    //busRegistrationConfigurator.AddConsumer<BookingRequestCompletedEventCustomer>();
//    //busRegistrationConfigurator.AddConsumer<BookingRequestFailedEventCustomer>();

//    busRegistrationConfigurator.UsingRabbitMq((busRegistrationContext, rabbitMqBusFactoryConfigurator) =>
//    {
//        rabbitMqBusFactoryConfigurator.Host(builder.Configuration["RabbitMqSetting:HostAddress"], "/", hostConfigurator =>
//        {
//            hostConfigurator.Username(builder.Configuration["RabbitMqSetting:Username"]);
//            hostConfigurator.Password(builder.Configuration["RabbitMqSetting:Password"]);
//        });

//        rabbitMqBusFactoryConfigurator.ReceiveEndpoint(RabbitQueueName.OrderRequestCompletedEventQueueName, endpoint =>
//        {
//            //endpoint.ConfigureConsumer<BookingRequestCompletedEventCustomer>(busRegistrationContext);
//        });

//        rabbitMqBusFactoryConfigurator.ReceiveEndpoint(RabbitQueueName.OrderRequestFailedEventQueueName, endpoint =>
//        {
//            //endpoint.ConfigureConsumer<BookingRequestFailedEventCustomer>(busRegistrationContext);
//        });
//    });
//});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddHttpClient();

//var services = new ServiceCollection();

//using var channel = GrpcChannel.ForAddress("https://localhost:7184");

//services
//    .addgrp<Greeter.GreeterClient>(o =>
//    {
//        o.Address = new Uri("https://localhost:5001");
//    })
//    .ConfigurePrimaryHttpMessageHandler(() =>
//    {
//        var handler = new HttpClientHandler();
//        handler.ServerCertificateCustomValidationCallback =
//            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

//        return handler;
//    });

//builder.WebHost.ConfigureKestrel(options =>
//{
//    var httpPort = 7184;
//    var grpcPort = 50004;

//    options.Listen(IPAddress.Any, httpPort, listenOptions =>
//    {
//        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
//        listenOptions.UseHttps();
//    });

//    options.Listen(IPAddress.Any, grpcPort, listenOptions =>
//    {
//        listenOptions.Protocols = HttpProtocols.Http2;
//    });

//    //options.ListenLocalhost(7184);
//    //options.Listen(IPAddress.Any, 5001, listenOptions =>
//    //{
//    //    listenOptions.Protocols = HttpProtocols.Http2;
//    //    //listenOptions.UseHttps("server.pfx", "7184");
//    //    //listenOptions.UseHttps("<path to .pfx file>", "<certificate password>");
//    //});
//});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCloudEvents();

app.MapActorsHandlers();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapControllers();
app.MapSubscribeHandler();
app.MapCustomHealthChecks("/hc", "/liveness", UIResponseWriter.WriteHealthCheckUIResponse);
app.MapGrpcService<AirlineService>();
app.Run();

