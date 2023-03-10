using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);

/*builder.Host.ConfigureLogging(loggingProvider =>
{
    loggingProvider.ClearProviders();
    loggingProvider.AddConsole();
    loggingProvider.AddDebug();
    loggingProvider.AddEventLog();
});*/

builder.Host.UseSerilog((HostBuilderContext context, LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration.WriteTo.Console();
    loggerConfiguration.WriteTo.File(path: "logs/applogs.txt", rollingInterval: RollingInterval.Day, fileSizeLimitBytes: 1048576, rollOnFileSizeLimit: true);
    loggerConfiguration.WriteTo.Seq(serverUrl: "http://localhost:5341/", restrictedToMinimumLevel: LogEventLevel.Debug);
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "JWT Authorization"
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new List<string>()
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("beingadmin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("role", "admin");
    });
});
var app = builder.Build();








// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
