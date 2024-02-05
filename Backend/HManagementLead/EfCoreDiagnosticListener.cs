using System.Diagnostics;

namespace HManagementLead
{
    public class EfCoreDiagnosticListener : IObserver<DiagnosticListener>
    {
        public void OnCompleted() { }

        public void OnError(Exception error) { }

        public void OnNext(DiagnosticListener value)
        {
            if (value.Name == "Microsoft.EntityFrameworkCore")
            {
                value.Subscribe(new EfCoreLogObserver());
            }
        }
    }
}
