using System.Net;
using MailKit.Security;

namespace Cronava.Service.Models;

public struct MailAccount
{
    public int id;
    public string address;
    public string displayName;
    public string username;
    public string password;
    public string sendingServer;
    public int sendingPort;
    public byte sendingSSLMode;
    public string receivingServer;
    public int receivingPort;
    public byte receivingSSLMode;
    public byte type;

    public bool IsIMAP()
    {
        return type == 0;
    }

    public bool IsPOP3()
    {
        return type == 1;
    }

    public SecureSocketOptions GetOutgoingSecureSocketOption() => GetSecureSocketOption(sendingSSLMode);
    public SecureSocketOptions GetIncomingSecureSocketOption() => GetSecureSocketOption(receivingSSLMode);

    public SecureSocketOptions GetSecureSocketOption(byte b)
    {
        switch (b)
        {
            case 0:
                return SecureSocketOptions.None;
            case 1:
                return SecureSocketOptions.Auto;
            case 2:
                return SecureSocketOptions.SslOnConnect;
            case 3:
                return SecureSocketOptions.StartTls;
            case 4:
                return SecureSocketOptions.StartTlsWhenAvailable;
            default:
                return SecureSocketOptions.Auto;
        }
    }

    public ICredentials GetCredentials()
    {
        return new NetworkCredential(username, EncryptionHelper.Decrypt(password));
    }

    public IEnumerable<object> GetItems(bool withId)
    {
        if (withId)
        {
            yield return id;
        }
        yield return address;
        yield return displayName;
        yield return username;
        yield return password;
        yield return sendingServer;
        yield return sendingPort;
        yield return sendingSSLMode;
        yield return receivingServer;
        yield return receivingPort;
        yield return receivingSSLMode;
        yield return type;
    }
}