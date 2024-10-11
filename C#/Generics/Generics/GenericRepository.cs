namespace Generics;

public class Entity
{
    public int Id { get; set; }

    public Entity(int id)
    {
        Id = id;
    }
}
public interface IRepository<T> where T : Entity
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}


public class GenericRepository<T>: IRepository<T> where T : Entity
{
    private List<T> _items = new List<T>();
    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public void Save()
    {
        Console.WriteLine("Items are saved. Items:");
        foreach (T item in _items)
        {
            Console.WriteLine(item.Id);
        }
    }

    public IEnumerable<T> GetAll()
    {
        return _items;
    }

    public T GetById(int id)
    {
        return _items.Find(item => item.Id == id);
        
    }
}

