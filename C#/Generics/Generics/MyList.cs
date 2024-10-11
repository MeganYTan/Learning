using System.Collections;

namespace Generics;

public class MyList<T>
{
    private T[] items;
    private int _count;

    public MyList()
    {
        items = new T[10];
        _count = 0;
    }

    private void Resize()
    {
        // make new array
        T[] newItems = new T[items.Length * 2];
        // copy
        for (int i = 0; i < _count; i++)
        {
            newItems[i]=items[i];
        }

        items = newItems;
    }
    public void Add(T element)
    {
        if (_count == items.Length)
        {
            Resize();
        }
        items[++_count] = element;
    }

    public T Remove(int index)
    {
        T element = items[index];
        for (int i = index; i < _count; i++)
        {
            items[i] = items[i + 1];
        }

        _count--;
        return element;
    }

    public bool Contains(T element)
    {
        foreach (T item in items)
        {
            if (item.Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public void Clear()
    {
        _count = 0;
        items = new T[10];
    }

    public void InsertAt(T element, int index)
    {
        if (_count == items.Length)
        {
            Resize();
        }

        for (int i =_count+1; i > index; i--)
        {
            items[i] = items[i-1];
        }

        items[index] = element;
        _count++;
    }

    public void DeleteAt(int index)
    {
        for (int i = index; i < _count; i++)
        {
            items[i] = items[i + 1];
        }

        _count--;
    }

    public T Find(int index)
    {
        return items[index];
    }
}