using Cronava.Service.Models;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;

namespace Cronava.Service.Service;

public sealed class IMAP(MailAccount account) : ServiceBroker(account)
{
    private ImapClient InitClient()
    {
#if DEBUG
        return new ImapClient(new ProtocolLogger(Console.OpenStandardOutput()));
#else
        return new ImapClient();
#endif
    }

    public override bool Validate()
    {
        try
        {
            using ImapClient client = InitClient();
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

    public void SyncMails(MailAccount account)
    {
        using ImapClient client = new ImapClient(new ProtocolLogger(Console.OpenStandardOutput()));

        client.Connect(account.receivingServer, account.receivingPort, account.GetIncomingSecureSocketOption());
        client.Authenticate(account.GetCredentials());

        IMailFolder inbox = client.Inbox;
        inbox.Open(FolderAccess.ReadWrite);
        IList<UniqueId> ids = inbox.Search(SearchQuery.All);
        foreach (UniqueId id in ids)
        {
            MailIdentifier identifier = MailIdentifier.From(account, id);
            if (!Configuration.mail.Exist(identifier))
            {
                MimeMessage message = inbox.GetMessage(id);
                MailMessage mail = new MailMessage
                {
                    mailId = MailIdentifier.From(account, id),
                    subject = message.Subject,
                    sender = message.Sender?.Name,
                    from = new DBList<string>(message.From.Select(x => x.Name)),
                    to = new DBList<string>(message.To.Select(x => x.Name)),
                    cc = new DBList<string>(message.Cc.Select(x => x.Name)),
                    bcc = new DBList<string>(message.Bcc.Select(x => x.Name)),
                    date = message.Date,
                    importance = (byte)message.Importance,
                    priority = (byte)message.Priority,
                    xPriority = (byte)message.XPriority,
                    resentFrom = new DBList<string>(message.ResentFrom.Select(x => x.Name)),
                    resentTo = new DBList<string>(message.ResentTo.Select(x => x.Name)),
                    resentCc = new DBList<string>(message.ResentCc.Select(x => x.Name)),
                    resentBcc = new DBList<string>(message.ResentBcc.Select(x => x.Name)),
                    resentDate = message.ResentDate
                };
                Configuration.mail.Safe(ref mail);
            }
        }

        client.Disconnect(true);
    }
}