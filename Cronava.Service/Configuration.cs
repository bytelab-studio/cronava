using System.Data;
using System.Runtime.InteropServices;
using Cronava.Service.Configurations;

namespace Cronava.Service;

public abstract class Configuration
{
    private static string GetStoragePath()
    {
        string basePath;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            basePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }
        else
        {
            throw new Exception("Unsupported operating system");
        }

        return Path.Combine(basePath, ".cronava");
    }

    private static string GetDBFile(string file)
    {
        return Path.Combine(GetStoragePath(), file);
    }


    public static AccountConfiguration account;
    public static MailConfiguration mail;

    static Configuration()
    {
		string basePath = GetStoragePath();
		string metaPath = Path.Combine(basePath, "meta");

		if (!Directory.Exists(basePath)) {
			Directory.CreateDirectory(basePath);
		}
		if (!Directory.Exists(metaPath)) {
			Directory.CreateDirectory(metaPath);
		}

        account = new AccountConfiguration(Path.Combine(metaPath, "accounts"));
        mail = new MailConfiguration(basePath);
    }

    protected string dbFile;

    protected Configuration(string dbFile)
    {
        this.dbFile = dbFile;
    }
}
