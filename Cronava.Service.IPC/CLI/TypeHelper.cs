namespace Cronava.Service.IPC.CLI;

public static class TypeHelper
{
    public static ushort ToUShort(string name, string value)
    {
        if (!ushort.TryParse(value, out ushort v))
        {
            Console.WriteLine($"The option -{name} requires a valid unsigned short integer");
            Environment.Exit(1);
        }

        return v;
    }

    public static byte ToByte(string name, string value)
    {
        if (!byte.TryParse(value, out byte v))
        {
            Console.WriteLine($"The option -{name} requires a valid byte integer");
            Environment.Exit(1);
        }

        return v;
    }
}