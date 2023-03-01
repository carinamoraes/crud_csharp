using crud_csharp.Database;
using crud_csharp.Repositories;
using crud_csharp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Conexão com o banco de dados
builder.Services.AddEntityFrameworkMySQL()
.AddDbContext<DB_Context>(
    options => options.UseMySQL(configuration.GetConnectionString("DataBase"))
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração das dependências dos repositórios
// Toda vez que alguém chamar a interface, o código sabe a classe que deve instanciar
builder.Services.AddScoped<IUser, UserRepository>(); // IUser implementa UserRepository

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