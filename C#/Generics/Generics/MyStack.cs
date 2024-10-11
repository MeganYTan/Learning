namespace Generics;

public class MyStack<T>
{
    List<T> stackList = new List<T>();
    public int Count()
    {
        return stackList.Count;
    }

    public T Pop()
    {
        T item = stackList[stackList.Count - 1];
        stackList.RemoveAt(stackList.Count - 1);
        return item;
    }

    public void Push(T item)
    {
        stackList.Add(item);
    }
}