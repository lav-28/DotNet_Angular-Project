using GraduateTraineeEnrollmentApi.Data.Contract;
using GraduateTraineeEnrollmentApi.Data.Implementation;
using GraduateTraineeEnrollmentApi.Models;
using GraduateTraineeEnrollmentApi.Services.Contract;
using GraduateTraineeEnrollmentApi.Services.Imlementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("AllowGraduateTraineeEnrollmentMVC", builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();

//Database Connection
builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("mydb"));
});

// Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
        };
    });


//register Dependency
builder.Services.AddScoped<IDegreeRepository, DegreeRepository>();
builder.Services.AddScoped<IDegreeService, DegreeService>();

builder.Services.AddScoped<IStreamRepository, StreamRepository>();
builder.Services.AddScoped<IStreamService, StreamService>();

builder.Services.AddScoped<IGraduateTraineeRepository, GraduateTraineeRepository>();
builder.Services.AddScoped<IGraduateTraineeService, GraduateTraineeService>();

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard authorization heading required using bearer scheme",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowGraduateTraineeEnrollmentMVC");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
