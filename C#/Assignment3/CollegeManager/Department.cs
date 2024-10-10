using CollegeManager.Interfaces;

namespace CollegeManager;

public class Department : IDepartmentService
{
    public string Name { get; private set; }
    private Instructor _headInstructor;
    private decimal _budget;
    private List<Course> _offeredCourses = new List<Course>();
    
    public Department(string name, Instructor headInstructor, decimal budget)
    {
        Name = name;
        _headInstructor = headInstructor;
        _budget = budget;
    }

    public Instructor GetDepartmentHead()
    {
        return _headInstructor;
    }

    public void SetDepartmentHead(Instructor instructor)
    {
        _headInstructor = instructor;
    }

    public void AddCourse(Course course)
    {
        _offeredCourses.Add(course);
    }

    public void RemoveCourse(Course course)
    {
        _offeredCourses.Remove(course);
    }

    public IEnumerable<Course> GetOfferedCourses()
    {
        return _offeredCourses;
    }

    public decimal GetBudget()
    {
        return _budget;
    }

    public void SetBudget(decimal budget)
    {
        _budget = budget;
    }
    
    
}