using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Services;
using CustomerManagement.Infrastructure.Data;
using CustomerManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // 1. create the web app builder

// Add services and repository 
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Use builder.Configuration to Oracle DB using the connection string from appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers(); // enble [ApiController] support

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Customer Management API",
        Version = "v1",
        Description = "A simple API for managing customers"
    });
});

var app = builder.Build(); 

// Configure the HTTP request pipeline (Middleware Configuration)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // enable Swagger docs
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Management API v1");
        // Remove this line to use default Swagger UI route (/swagger)
        // c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection(); // use secure HTTPS
app.UseAuthorization(); // enable [Authorize] attributes
app.MapControllers(); // map routes to controller endpoints

app.Run(); // start the web server