using FubuMVC.Validation;
using SkuskaApp.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICOMService, COMService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddCors();
builder.Services.AddMvc();
builder.Services.AddDbContext<DataContext>(
    option => option.UseSqlServer("Server=DESKTOP-G8EB8RG;Database=Zadanie_Data;TrustServerCertificate=True;User=guest", builder =>
    {
    }
    ));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();