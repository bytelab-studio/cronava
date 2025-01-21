using Cronava.Service.IPC.CLI;
using Mono.Options;

namespace Cronava.Service.IPC;

public static class Program
{
    public static int Main(string[] args)
    {
        CommandSet commandSet = new CommandSet("Cronava")
        {
            new EmailCommandSet()
        };

        return commandSet.Run(args);
    }
}