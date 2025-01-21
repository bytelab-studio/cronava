using Cronava.Service.Models;
using MailKit;
using MailKit.Net.Pop3;

namespace Cronava.Service.Service;

public sealed class POP3(MailAccount account) : ServiceBroker(account)
{
    private Pop3Client InitClient()
    {
#if DEBUG
        return new Pop3Client(new ProtocolLogger(Console.OpenStandardOutput()));
#else
        return new Pop3Client();
#endif
    }

    public override bool Validate()
    {
        try
        {
            using Pop3Client client = InitClient();
            client.Connect(account.receivingServer, account.receivingPort, account.GetIncomingSecureSocketOption());
            client.Authenticate(account.GetCredentials());
            client.Disconnect(true);
            return true;
        }
        catch
        {
            return false;
        }
    }
}