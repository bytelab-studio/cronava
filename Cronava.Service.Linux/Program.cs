using System.Net.NetworkInformation;
using Cronava.Service.Models;
using Cronava.Service.Service;

namespace Cronava.Service.Linux;

public sealed class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(new Ping().Send("mail.bytelab.studio").Status);
        MailAccount account = new MailAccount()
        {
            address = "christoph@bytelab.studio",
            receivingPort = 993,
            receivingServer = "mail.bytelab.studio",
            username = "christoph@bytelab.studio"
        };

        // new IMAP().SyncMails(account);
    }
}
