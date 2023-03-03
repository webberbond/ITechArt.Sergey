using Xunit.Sdk;

namespace XUnitCalculator.Calculator;

internal sealed class PrintableDiagnosticMessage : DiagnosticMessage
{
    public PrintableDiagnosticMessage(string message)
        : base(message)
    {
    }

    public override string ToString() => Message;
}