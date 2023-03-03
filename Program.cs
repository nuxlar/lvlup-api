using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using LvlUpApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DOMAIN dev-buobm2eea412cbsg.us.auth0.com
// CLIENT S4NvQqmvVjtytjzhnILH7gghcz8qLAlM
builder.Services.AddControllers();
// Add Authentication Services
builder.Services.AddAuthentication(options =>
        {
          options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
          options.Authority = "https://dev-buobm2eea412cbsg.us.auth0.com/";
          options.Audience = "http://localhost:5227/";
        });
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
// Enable authentication middleware
app.UseAuthentication();

app.MapControllers();

app.Run();
