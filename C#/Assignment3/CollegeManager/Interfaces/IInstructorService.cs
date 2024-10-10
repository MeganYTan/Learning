namespace CollegeManager.Interfaces;

public interface IInstructorService : IPersonService
{
    int CalculateYearsOfExperience();
}