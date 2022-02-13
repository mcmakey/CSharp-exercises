using Microsoft.EntityFrameworkCore;
using CardService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<CardServiceContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=cardappdb5 ;Trusted_Connection=True;")
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
