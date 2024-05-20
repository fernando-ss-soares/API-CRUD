using Microsoft.EntityFrameworkCore;
using Taskify.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Banco de Dados Mysql do appsettings.json
// var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");
var connectionString = builder.Configuration.GetConnectionString("TaskConnectionPG");

// Adicionando a conexão com banco de dados a API
//builder.Services.AddDbContext<FilmeContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddDbContext<TaskContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.
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

app.UseAuthorization();

app.MapControllers();

app.Run();
