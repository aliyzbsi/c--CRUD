using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;


Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dbPassword=Environment.GetEnvironmentVariable("DB_PASSWORD");
System.Console.WriteLine($"DB_PASSWORD:{dbPassword??"NULL"}");
var connectionString=builder.Configuration.GetConnectionString("DefaultConnection");
connectionString = connectionString.Replace("${DB_PASSWORD}", dbPassword ?? "");
Console.WriteLine($"Connection String: {connectionString}");
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseNpgsql(connectionString));

builder.Services.AddControllers();
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
