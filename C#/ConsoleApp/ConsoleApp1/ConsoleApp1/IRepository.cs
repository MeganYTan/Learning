namespace ConsoleApp1;

public abstract class DbEntity
{
    public int Id { get; set; }
}


public interface IRepository<T> where T: DbEntity
{
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(int id);
}

public class PersonRepository : IRepository<Person>
{
    public List<Person> Persons = new List<Person>();
    public void Add(Person person)
    {
        Persons.Add(person);
    }

    public void Update(Person person)
    {
        Person defaultPerson = new Teacher("", "", 0);
        Person existingPerson = Persons.FirstOrDefault(p => p.Id == person.Id);
        if (existingPerson != null)
        {
            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
        }
        
    }

    public void Delete(int id)
    {
        Persons.Remove(Persons.FirstOrDefault(p => p.Id == id));
    }
}

