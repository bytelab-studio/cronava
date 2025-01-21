using Mono.Options;

namespace Cronava.Service.IPC.CLI;

public sealed class EmailCommandSet : CommandSet
{


    public EmailCommandSet() : base("email")
    {
        Add(new AddCommand());
    }
}