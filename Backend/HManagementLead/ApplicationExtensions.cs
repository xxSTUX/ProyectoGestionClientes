using Serilog;
using System.Diagnostics;

namespace HManagementLead
{
    public static class ApplicationExtensions
    {
        public static void ConfigureSerilogForEFCore(this WebApplication app)
        {
            var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();

            // Configurar Serilog para capturar eventos de EF Core
            loggerFactory.AddSerilog();
            DiagnosticListener.AllListeners.Subscribe(new EfCoreDiagnosticListener());
        }
    }
}
