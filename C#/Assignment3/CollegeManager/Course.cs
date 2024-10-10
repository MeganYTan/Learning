using CollegeManager.Interfaces;

namespace CollegeManager;

public class Course : ICourseService
{
    public string CourseName { get; private set; }
    private List<Student> _enrolledStudents = new List<Student>();

    public Course(string courseName)
    {
        CourseName = courseName;
    }

    public void AddStudent(Student student)
    {
        if (!_enrolledStudents.Contains(student))
        {
            _enrolledStudents.Add(student);
        }
    }

    public void RemoveStudent(Student student)
    {
        _enrolledStudents.Remove(student);
    }

    public IEnumerable<Student> GetEnrolledStudents()
    {
        return _enrolledStudents;
    }
}