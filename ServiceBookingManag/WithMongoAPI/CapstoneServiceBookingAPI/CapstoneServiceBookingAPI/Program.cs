using CapstoneServiceBookingAPI.Configuration; // Import the namespace for your settings class
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using CapstoneServiceBookingAPI.Repositories;
using CapstoneServiceBookingAPI.Services;
using MongoDB.Driver;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure MongoDB settings
builder.Services.Configure<CapstoneServiceBookingDbSettings>(
    builder.Configuration.GetSection("CapstoneServiceBookingDbSettings")
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

// Configure MongoDB
var mongoSettings = builder.Configuration.GetSection("CapstoneServiceBookingDbSettings").Get<CapstoneServiceBookingDbSettings>();
builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoSettings.ConnectionString));
builder.Services.AddScoped<IMongoDatabase>(provider =>
{
    var client = provider.GetRequiredService<IMongoClient>();
    return client.GetDatabase(mongoSettings.DatabaseName);
});

// Register repositories and services
builder.Services.AddScoped<IAppUserRepo, AppUserRepo>();
builder.Services.AddScoped<IAppUserService, AppUserService>();
builder.Services.AddScoped<IAppProductRepo, AppProductRepo>();
builder.Services.AddScoped<IAppProductService, AppProductService>();
builder.Services.AddScoped<IAppServiceRequestRepo, AppServiceRequestRepo>();
builder.Services.AddScoped<IAppServiceRequestService, AppServiceRequestService>();
builder.Services.AddScoped<IAppServiceRequestReportRepo, AppServiceRequestReportRepo>();
builder.Services.AddScoped<IAppServiceRequestReportService, AppServiceRequestReportService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AppPasswordService>();

// JWT Configuration
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
    // Uncomment if you have role-based policies
    // options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    // options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication(); // Ensure authentication is enabled
app.UseAuthorization();

app.MapControllers();

app.Run();
