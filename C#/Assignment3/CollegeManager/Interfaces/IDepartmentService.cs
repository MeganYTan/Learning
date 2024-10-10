namespace CollegeManager.Interfaces;

public interface IDepartmentService
{
    Instructor GetDepartmentHead();
    void SetDepartmentHead(Instructor instructor);

    void AddCourse(Course course);
    void RemoveCourse(Course course);
    IEnumerable<Course> GetOfferedCourses();

    decimal GetBudget();
    void SetBudget(decimal budget);
}