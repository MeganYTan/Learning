namespace CollegeManager.Interfaces;

public interface IStudentService : IPersonService
{
    void EnrollInCourse(Course course);
    double CalculateGPA();
}