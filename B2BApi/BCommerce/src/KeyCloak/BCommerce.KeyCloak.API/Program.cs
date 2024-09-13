using BCommerce.KeyCloak.API.Infrastructure.Context;
using BCommerce.KeyCloak.API.Repository;
using BCommerce.KeyCloak.API.Services;
using BCommerce.KeyCloak.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AppDbContext)));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
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

builder.Services.AddHttpClient();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IRoleRepository,RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
