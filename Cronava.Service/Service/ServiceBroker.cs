using Cronava.Service.Models;

namespace Cronava.Service.Service;

public abstract class ServiceBroker
{
    protected MailAccount account;

    protected ServiceBroker(MailAccount account)
    {
        this.account = account;
    }

    // public abstract void SyncMails(MailAccount account);

    public abstract bool Validate();


    public static ServiceBroker Get(MailAccount account)
    {
        if (account.IsIMAP())
        {
            return new IMAP(account);
        }
        if (account.IsPOP3())
        {
            return new POP3(account);
        }

        throw new Exception("Invalid account type");
    }
}