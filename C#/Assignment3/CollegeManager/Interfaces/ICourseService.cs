namespace CollegeManager.Interfaces;

public interface ICourseService
{
    void AddStudent(Student student);
    void RemoveStudent(Student student);
    IEnumerable<Student> GetEnrolledStudents();
}