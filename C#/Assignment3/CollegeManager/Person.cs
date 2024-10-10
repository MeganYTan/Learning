namespace CollegeManager;
using System.Collections.Generic;
public abstract class Person
{
    // age, salary, address
    public string Name { get; set; }
    public DateTime DateOfBirth { get; private set; }
    
    private List<string> _addresses = new List<string>();


    private decimal _salary = 0;

    public virtual decimal Salary
    {
        get => _salary;
        set
        {
            if (value > 0)
            {
                _salary = value;
            }
        }
    }

    public Person(String name, DateTime dateOfBirth, decimal salary = 0)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        Salary = salary;
    }
    // calculate age
    public int CalculateAge()
    {
        int age = DateTime.Now.Year - DateOfBirth.Year;
        if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear) age--;
        return age;
    }
    // get addresses
    public IEnumerable<string> GetAddresses()
    {
        return _addresses;
    }

    public void AddAddress(string address)
    {
        _addresses.Add(address);
    }
    
}