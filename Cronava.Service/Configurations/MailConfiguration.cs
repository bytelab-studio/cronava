using System.Data;
using Cronava.Service.Models;

namespace Cronava.Service.Configurations;

public sealed class MailConfiguration(string dbFile) : Configuration(dbFile)
{
    public bool Exist(MailIdentifier identifier)
    {
		return false;
    }

    public bool Safe(ref MailMessage mail)
    {
    	return false;
	}

    public bool MakeFolderStructure()
    {
        return false;
    }
}
