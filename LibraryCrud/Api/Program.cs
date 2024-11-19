using AspNetCoreRateLimit;
using LibraryCrud.Api.Extensions;
using LibraryCrud.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryCrudContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//Se añaden los metodos de extension
builder.Services.ConfigureCors();
builder.Services.ConfigureRateLimit();
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseIpRateLimiting();
app.UseAuthorization();

app.MapControllers();

app.Run();
