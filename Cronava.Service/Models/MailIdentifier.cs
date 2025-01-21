using MailKit;

namespace Cronava.Service.Models;

public struct MailIdentifier
{
    public int account;
    public uint uid;

    public string key => $"{account}:{uid}";

    public static MailIdentifier From(MailAccount account, UniqueId uid)
    {
        return new MailIdentifier
        {
            account = account.id,
            uid = uid.Id
        };
    }
}