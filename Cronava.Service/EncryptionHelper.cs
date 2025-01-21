using System.Security.Cryptography;
using System.Text;

namespace Cronava.Service;

public static class EncryptionHelper
{
    private static readonly byte[] key = "12345678912345678912345678912345"u8.ToArray();
    private static readonly byte[] iv = "1234567891234567"u8.ToArray();

    public static string Encrypt(string text)
    {
        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        using ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using MemoryStream ms = new MemoryStream();
        using CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        using (StreamWriter writer = new StreamWriter(cs))
        {
            writer.Write(text);
        }

        return Convert.ToBase64String(ms.ToArray());
    }

    public static string Decrypt(string cipherText)
    {
        byte[] buffer = Convert.FromBase64String(cipherText);
        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        using ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using MemoryStream ms = new MemoryStream(buffer);
        using CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using StreamReader reader = new StreamReader(cs);
        return reader.ReadToEnd();
    }
}