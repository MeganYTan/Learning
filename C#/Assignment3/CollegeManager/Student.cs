using CollegeManager.Interfaces;

namespace CollegeManager;

public class Student : Person, IStudentService
{
    private List<Course> _courses = new List<Course>();
    private Dictionary<Course, char> _grades = new Dictionary<Course, char>();

    public Student(string name, DateTime dateOfBirth) : base(name, dateOfBirth)
    {
    }

    public void EnrollInCourse(Course course)
    {
        _courses.Add(course);
        course.AddStudent(this);
    }

    public void DropFromCourse(Course course)
    {
        _courses.Remove(course);
        _grades.Remove(course);
        course.RemoveStudent(this);
    }

    public void AssignGrade(Course course, char grade)
    {
        if (_courses.Contains(course))
        {
            _grades[course] = grade;
        }
    }

    public double CalculateGPA()
    {
        if (_grades.Count == 0) return 0.0;
        double totalPoints = 0;
        foreach (char grade in _grades.Values)
        {
            totalPoints += GradeToPoint(grade);
        }
        return totalPoints / _grades.Count;
    }

    private double GradeToPoint(char grade)
    {
        return grade switch
        {
            'A' => 4.0,
            'B' => 3.0,
            'C' => 2.0,
            'D' => 1.0,
            'F' => 0.0,
            _ => 0.0
        };
    }
    
}