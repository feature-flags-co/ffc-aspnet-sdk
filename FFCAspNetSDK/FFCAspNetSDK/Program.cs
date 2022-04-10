using Microsoft.EntityFrameworkCore;
using DBMigrationDemo.Data;
using DBMigrationDemo.Repositories;
using DBMigrationDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0
builder.Services.AddDbContext<SqlDBContext >(options => options.UseInMemoryDatabase(databaseName: "FeatureFlagDB"));
builder.Services.AddTransient<IFeatureFlagRepository, FeatureFlagRepository>();
builder.Services.AddTransient<IFeatureFlagService, FeatureFlagService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
