using CollegeManager.Interfaces;

namespace CollegeManager;

public class Instructor : Person, IInstructorService
{
    public Department Department { get; set; }
    public DateTime JoinDate { get; set; }
    
    public Instructor(string name, DateTime dateOfBirth, DateTime joinDate, Department department) 
        : base(name, dateOfBirth)
    {
        JoinDate = joinDate;
        Department = department;
    }

    public int CalculateYearsOfExperience()
    {
        return DateTime.Now.Year - JoinDate.Year;
    }

    public new decimal Salary
    {
        get
        {
            int experienceYears = CalculateYearsOfExperience();
            return base.Salary + (experienceYears * 1000); 
        }
        set
        {
            base.Salary = value;
        }
    }
    
    public bool IsHeadOfDepartment()
    {
        return Department.GetDepartmentHead() == this;
    }
}