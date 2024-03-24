using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;

namespace csharp.Core;

internal class PlainLogFormatter : ConsoleFormatter
{
    internal const string FormatterName = "PlainLogger";
    
    public PlainLogFormatter() : base(FormatterName)
    {
    }

    public override void Write<TState>(in LogEntry<TState> logEntry, IExternalScopeProvider scopeProvider, TextWriter textWriter)
    {
        var message = logEntry.Formatter(logEntry.State, logEntry.Exception);
        textWriter.WriteLine(message);
    }
}