using HManagementLead;
using HManagementLead.Bll;
using HManagementLead.Bll.Interfaces;
using HManagementLead.Dal;
using HManagementLead.Dal.Interfaces;
using HManagementLead.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
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

//Configuracion CORS
builder.Services.AddCors(options => {
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:4200")  // Aqui ponemos la IP y puerto del frontend
            .AllowAnyMethod()
            .AllowAnyHeader());
});

//Configuración ef core 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var configuration = builder.Configuration;
    //var connectionString = configuration.GetConnectionString("Gestion");
    var connectionString = configuration.GetConnectionString("DefaultConnection"); //Si creas la BBDD con migraciones usa esta connection string.
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
builder.Services.AddScoped<ILicitacionService, LicitacionService>();
builder.Services.AddScoped<ILicitacionRepository, LicitacionRepository>();
builder.Services.AddScoped<IContactoService, ContactoService>();
builder.Services.AddScoped<IContactoRepository, ContactoRepository>();
builder.Services.AddScoped<IFacturacionService, FacturacionService>();
builder.Services.AddScoped<IFacturacionRepository, FacturacionRepository>();
builder.Services.AddScoped<IPuestoService, PuestoService>();
builder.Services.AddScoped<IPuestoRepository, PuestoRepository>();



//Fin de elementos a sacar a un proyecto externo

var app = builder.Build();

//Anadimos las politicas de CORS
app.UseCors("AllowSpecificOrigin");

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
