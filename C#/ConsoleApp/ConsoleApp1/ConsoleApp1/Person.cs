namespace ConsoleApp1;

public abstract class Person: DbEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    private int _age;

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value > 0 && value < 100)
            {
                _age = value;
            }
        }
    }

    protected virtual string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}: {Age}";
    }

    public abstract void AbstractMethod(int a);
}

public class Teacher : Person
{
    public Teacher(string firstName, string lastName, int age) : base(firstName, lastName, age)
    {
        
    }
    protected override string GetFullName()
    {
        return $"Mr. {base.GetFullName()}";
    }

    public sealed override void AbstractMethod(int a)
    {
        
    }
}