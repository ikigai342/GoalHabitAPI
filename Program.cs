global using GoalHabitAPI.Models;
global using GoalHabitAPI.Models.Dtos;
global using GoalHabitAPI.Data;

global using Microsoft.EntityFrameworkCore;

using GoalHabitAPI.Services.GoalService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGoalService, GoalService>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "AngularOrigin", policy =>
        policy.WithOrigins("http://localhost:4200")
       .AllowAnyMethod()
       .AllowAnyHeader());
    });

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

app.UseCors("AngularOrigin");

app.Run();
