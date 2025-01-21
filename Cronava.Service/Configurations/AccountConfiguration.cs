using System.Data;
using Cronava.Service.Models;

namespace Cronava.Service.Configurations;

public sealed class AccountConfiguration : Configuration
{
	public const char SEPERATOR = ':';
	private List<MailAccount> accounts;

	public AccountConfiguration(string dbFile) : base(dbFile) {
		LoadData();
	}

    public MailAccount[] GetMailAccounts()
    {
        return accounts.ToArray();
    }

    public void LoadData()
    {
		accounts = new List<MailAccount>();

		if (!File.Exists(dbFile)) {
			return;
		}

		string content = File.ReadAllText(dbFile);
		string[] lines = content.Split('\n');
		foreach (string line in lines) {
			string[] items = line.Split(SEPERATOR);
			
            accounts.Add(new MailAccount
            {
                id = int.Parse(items[0]),
                address = items[1],
                displayName = items[2],
                username = items[3],
                password = items[4],
                sendingServer = items[5],
                sendingPort = int.Parse(items[6]),
                sendingSSLMode = byte.Parse(items[7]),
                receivingServer = items[8],
                receivingPort = int.Parse(items[9]),
                receivingSSLMode = byte.Parse(items[10]),
                type =  byte.Parse(items[11])
			});
		}
    }

	private void StoreData() {
		using StreamWriter writer = new StreamWriter(dbFile);

		foreach (MailAccount account in accounts) {
			int i = 0;
			foreach (object item in account.GetItems(true)) {
				if (i++ != 0) {
					writer.Write(SEPERATOR);
				}
				writer.Write(item.ToString());
			}
			writer.WriteLine();
		}
	}
}
