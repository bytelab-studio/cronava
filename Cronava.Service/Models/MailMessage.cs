using MimeKit;

namespace Cronava.Service.Models;

public struct MailMessage
{
    public int id;
    public MailIdentifier mailId;

    // Standard email headers
    public string subject;
    public string body;
    public string sender;
    public DBList<string> from;
    public DBList<string> to;
    public DBList<string> cc;
    public DBList<string> bcc;
    public DateTimeOffset date;

    // Priority and importance
    public byte importance; // e.g., "high", "normal", "low"
    public byte priority ; // e.g., "urgent", "non-urgent"
    public byte xPriority; // e.g., 1 (highest) to 5 (lowest)

    // Resent headers (used for re-sent emails)
    public DBList<string> resentFrom;
    public DBList<string> resentTo;
    public DBList<string> resentCc;
    public DBList<string> resentBcc;
    public DateTimeOffset resentDate;

    // Attachments
    // public DBList<AttachmentData> Attachments { get; set; }

    // Custom headers
    // public DBList<string> customHeaders;

    public IEnumerable<object> GetItems(bool withId)
    {
        if (withId)
        {
            yield return id;
        }
        yield return mailId.key;
        yield return subject;
        yield return body;
        yield return sender;
        yield return from.Deserialize();
        yield return to.Deserialize();
        yield return cc.Deserialize();
        yield return bcc.Deserialize();
        yield return date;
        yield return importance;
        yield return priority;
        yield return xPriority;
        yield return resentFrom.Deserialize();
        yield return resentTo.Deserialize();
        yield return resentCc.Deserialize();
        yield return resentBcc.Deserialize();
        yield return resentDate;
    }

    public struct Attachment
    {
        public string fileName;
        public byte[] content;
        public string contentType;
    }
}