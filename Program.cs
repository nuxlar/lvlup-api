using Microsoft.EntityFrameworkCore;
using LvlUpApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HasDoneContext>(opt =>
    opt.UseInMemoryDatabase("HasDoneList"));
builder.Services.AddDbContext<HabitContext>(opt =>
    opt.UseInMemoryDatabase("HabitList"));
builder.Services.AddDbContext<UserContext>(opt =>
    opt.UseInMemoryDatabase("UserList"));
// dotnet-aspnet-codegenerator controller -name UsersController -async -api -m User -dc UserContext -outDir Controllers
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
