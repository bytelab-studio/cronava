using System.Collections;
using System.Text;

namespace Cronava.Service;

public sealed class DBList<T> : IEnumerable<T> {
	public const char SEPERATOR = ';';

    private T[] items;

    public int Length => items.Length;

    public DBList(T[] items)
    {
        this.items = items;
    }

    public DBList(IEnumerable<T> items)
    {
        this.items = items.ToArray();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return (IEnumerator<T>)items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public T this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    public string Deserialize()
    {
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < items.Length; i++)
        {
            T item = items[i];
            if (i != 0)
            {
                builder.Append(SEPERATOR);
            }
            builder.Append(item);
        }
        return builder.ToString();
    }

    public static DBList<T> From(string str, Func<string, T> parser)
    {
        List<T> items = new List<T>();

        foreach (string s in str.Split(SEPERATOR))
        {
            items.Add(parser(s));
        }

        return new DBList<T>(items.ToArray());
    }

    public static DBList<T> Empty()
    {
        return new DBList<T>(Array.Empty<T>());
    }
}
