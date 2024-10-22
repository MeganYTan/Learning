using ConsoleApp1;


public class Program
{
    static EmployeeRepository employees = new EmployeeRepository();

    public static void PrintAllFieldsAndProperties(dynamic obj)
    {
        // Get the type of the object
        Type type = obj.GetType();

        // Print all properties
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            Console.Write($"{property.Name}: {property.GetValue(obj)}, ");
        }

        // Print all fields (if any)
        var fields = type.GetFields();
        foreach (var field in fields)
        {
            Console.Write($"{field.Name}: {field.GetValue(obj)}, ");
        }
        Console.WriteLine();
    }
    public static void PrintEnumerableObject(IEnumerable<dynamic> employees)
    {
        foreach (var employee in employees)
        {
            PrintAllFieldsAndProperties(employee);
        }
    }

    public static void PrintEnumerable(IEnumerable<Object> arr)
    {
        foreach (var a in arr)
        {
            Console.WriteLine(a);
        }
    }
    public static void SelectDemo()
    {
        var result = employees.GetEmployees().Select(e => e);
        var result2 = from employee in employees.GetEmployees() select employee;
    }

    public static void SelectFields()
    {
        var result = from employee in employees.GetEmployees()
            select new
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Salary = employee.Salary
            };
        var result2 = employees.GetEmployees().Select(e => new {Id = e.Id, Salary = e.Salary});
        PrintEnumerable(result2);
    }

    public static void SelectDistinct()
    {
        var result = employees.GetEmployees().Select(e => e.Department).Distinct();
        PrintEnumerable(result);
    }

    public static void FirstOrDefault()
    {
        var result = employees.GetEmployees().Select(e => new
        {
            Id = e.Id,
            FullName = e.FullName,
            Department = e.Department
        }).FirstOrDefault(e => e.Department == "ls")
            ??new { Id = 0, FullName = "Unknown", Department = "N/A" };
        PrintAllFieldsAndProperties(result);
            ;
    }

    public static void OrderBy()
    {
        var result = from e in employees.GetEmployees() orderby e.Salary descending select new
        {
            Id = e.Id,
            FullName = e.FullName
        };
        
        var result2 = employees.GetEmployees()
                .OrderBy(e => e.Salary)
            .Select(e => new { Id = e.Id, FullName = e.FullName });
        PrintEnumerableObject(result2);
    }

    public static void Where()
    {
        var result = employees.GetEmployees().Select(e => e)
            .Where(e => e.Department == "HR")
            .OrderByDescending(e => e.Salary);
        var result2 = from e in employees.GetEmployees() where e.Department == "HR" orderby e.Salary descending select e;
        PrintEnumerableObject(result);
    }
    public static void GroupBy()
    {
        var result = employees.GetEmployees().GroupBy(employee => employee.Department);
        foreach (var group in result)
        {
            Console.WriteLine($"{group.Key} Department");
            foreach (var employee in group )
            {
                Console.WriteLine(employee.Id + "\t" + employee.FullName + "\t" + employee.Salary);
            }
        }
    }

    public static void Aggregation()
    {
        var result = employees.GetEmployees().GroupBy(employee => employee.Department).Select(group => new
        {
            Department = group.Key,
            Salary = group.Sum(e => e.Salary)
        });
        var result2 = from e in employees.GetEmployees() group e by e.Department into departmentGroup
            select new
        {
            Department = departmentGroup.Key,
            Salary = departmentGroup.Sum(e => e.Salary)
        };
        PrintEnumerableObject(result);
    }
    public static void Main(string[] args)
    {
        Aggregation();
    }
}

