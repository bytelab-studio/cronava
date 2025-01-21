using Cronava.Service.Models;
using Cronava.Service.Service;
using Mono.Options;

namespace Cronava.Service.IPC.CLI;

public sealed class AddCommand : Command
{
    private bool help;
    private string address;
    private string displayName;
    private string username;
    private string password;
    private string sendingServer;
    private ushort sendingPort;
    private byte sendingSSLMode;
    private string receivingServer;
    private ushort receivingPort;
    private byte receivingSSLMode;
    private byte type;

    public AddCommand() : base("add", "Adds a email account")
    {
        Options = new OptionSet()
        {
            "Usage: Cronava.IPC email add <options>",
            {
                "h|help", "Prints this help text", v => help = true
            },
            {
                "address=", "The {email} address of the account", v => address = v
            },
            {
                "display=", "A {display} string of the account", v => displayName = v
            },
            {
                "username=", "The {username} of the account when mostly the same as address", v => username = v
            },
            {
                "password=", "The {password} of the account", v => password = v
            },
            {
                "sserver=", "The sending {server}", v => sendingServer = v
            },
            {
                "sport=", "The {port} of the sending server", v => sendingPort = TypeHelper.ToUShort("sport", v)
            },
            {
                "sssl=", "The SSL {mode} of the sending server", v => sendingSSLMode = TypeHelper.ToByte("sssl", v)
            },
            {
                "rserver=", "The receiving {server}", v => receivingServer = v
            },
            {
                "rport=", "The {port} of the receiving server", v => receivingPort = TypeHelper.ToUShort("sport",v)
            },
            {
                "rssl=", "The SSL {mode} of the receiving server", v => receivingSSLMode = TypeHelper.ToByte("rssl", v)
            },
            {
                "type=", "The account {type}", v => type = TypeHelper.ToByte("type", v)
            }
        };
    }

    public override int Invoke(IEnumerable<string> arguments)
    {
        Options.Parse(arguments);
        if (help)
        {
            Options.WriteOptionDescriptions(Console.Out);
            return 0;
        }

        MailAccount account = new MailAccount()
        {
            address = address,
            displayName =  displayName,
            username = username,
            password = EncryptionHelper.Encrypt(password),
            sendingServer =  sendingServer,
            sendingPort =  sendingPort,
            sendingSSLMode = sendingSSLMode,
            receivingServer = receivingServer,
            receivingPort = receivingPort,
            receivingSSLMode = receivingSSLMode,
            type = type
        };

        if (!ServiceBroker.Get(account).Validate())
        {
            OutputHelper.SendingOutput(1, "Validation failed of the mail account");
        }

        if (!Configuration.account.Save(account))
        {
            OutputHelper.SendingOutput(1, "Email storing failed");
        }

        Configuration.mail.MakeFolderStructure();



        return 0;
    }
}