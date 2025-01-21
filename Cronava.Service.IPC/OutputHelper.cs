using System.Diagnostics.CodeAnalysis;

namespace Cronava.Service.IPC;

public static class OutputHelper
{
    [DoesNotReturn]
    public static void SendingOutput(int code, string message)
    {
        Console.WriteLine($"{code};{message}");
        Environment.Exit(code);
    }
}