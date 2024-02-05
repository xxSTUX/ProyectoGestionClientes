using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Diagnostics;

namespace HManagementLead
{
    public class EfCoreLogObserver : IObserver<KeyValuePair<string, object>>
    {
        private const string CommandExecutingEventName = "CommandExecuting";

        public void OnCompleted() { }

        public void OnError(Exception error) { }

        public void OnNext(KeyValuePair<string, object> value)
        {
            if (value.Key == CommandExecutingEventName)
            {
                var eventData = (CommandEventData)value.Value;
                var commandText = eventData.Command.CommandText;
                Console.WriteLine($"Executing SQL: {commandText}");
            }
        }
    }
}
