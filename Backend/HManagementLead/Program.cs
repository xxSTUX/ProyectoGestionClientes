using HManagementLead;
using HManagementLead.Bll;
using HManagementLead.Bll.Interfaces;
using HManagementLead.Dal;
using HManagementLead.Dal.Interfaces;
using HManagementLead.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración del logging
builder.Configuration.AddJsonFile("appsettings.json");
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

//Configuración ef core 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var configuration = builder.Configuration;
    var connectionString = configuration.GetConnectionString("Prueba");
    options.UseSqlServer(connectionString)
    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddSerilog()));
});


//Inyección de dependencias, sacar a un proyecto externo
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProyectoService, ProyectoService>();
builder.Services.AddScoped<IProyectoRepository, ProyectoRepository>();
builder.Services.AddScoped<ISeguimientoService, SeguimientoService>();
builder.Services.AddScoped<ISeguimientoRepository, SeguimientoRepository>();


//Fin de elementos a sacar a un proyecto externo

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureSerilogForEFCore();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
