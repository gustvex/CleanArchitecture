using CleanArchitecture.CrossCutting.IoC;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

// Load .env file from solution root
var projectRoot = Directory.GetCurrentDirectory();
var solutionRoot = Directory.GetParent(projectRoot)?.FullName ?? projectRoot;
var envFilePath = Path.Combine(solutionRoot, ".env");

Console.WriteLine($"Looking for .env at: {envFilePath}");
Console.WriteLine($"File exists: {File.Exists(envFilePath)}");

if (File.Exists(envFilePath))
{
    DotNetEnv.Env.Load(envFilePath);
    Console.WriteLine($"DB_PASSWORD loaded: {!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DB_PASSWORD"))}");
}
else
{
    Console.WriteLine("Warning: .env file not found!");
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database
builder.Services.AddDatabase(builder.Configuration);

// Add Dependencies (MediatR, Repositories)
builder.Services.AddDependencies();

var app = builder.Build();

// Auto-apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); // Aplica migrations automaticamente
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
