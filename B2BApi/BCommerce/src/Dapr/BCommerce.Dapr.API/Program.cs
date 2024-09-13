using BCommerce.Dapr.API;
using BCommerce.Dapr.API.Helpers;
using BCommerce.Dapr.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfiles));
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddCustomApplicationServices();

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

app.UseRouting();
app.UseCloudEvents();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();