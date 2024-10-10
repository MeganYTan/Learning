using CollegeManager;

Instructor mathDepartmentHead = new Instructor("John", new DateTime(1990, 1, 1), new DateTime(2015, 12, 31), null);
Department mathDepartment = new Department("Math", mathDepartmentHead, 50000);
mathDepartmentHead.Department = mathDepartment;

Instructor mathProfessor = new Instructor("Jane", new DateTime(1989, 1, 1), new DateTime(2020, 5, 5), mathDepartment);

Console.WriteLine($"Is {mathProfessor.Name} head of {mathProfessor.Department}?{mathProfessor.IsHeadOfDepartment()}");
Console.WriteLine($"Is {mathDepartmentHead.Name} head of {mathDepartmentHead.Department}?{mathDepartmentHead.IsHeadOfDepartment()}");
Console.WriteLine($"{mathProfessor.Name} started on {mathProfessor.JoinDate} and has salary: {mathProfessor.Salary}");
Console.WriteLine($"{mathDepartmentHead.Name} started on {mathDepartmentHead.JoinDate} and has salary: {mathDepartmentHead.Salary}");


Course calculus1 = new Course("Calculus 1");
Course calculus2 = new Course("Calculus 2");
mathDepartment.AddCourse(calculus1);
mathDepartment.AddCourse(calculus2);
Student aaron = new Student("Aaron", new DateTime(1999, 6, 6));
aaron.EnrollInCourse(calculus1);

Console.WriteLine($"Math deparment has the following courses:");
foreach (Course course in mathDepartment.GetOfferedCourses())
{
    Console.WriteLine(course.CourseName);
    Console.WriteLine($"{course.CourseName} has the following students:");
    foreach (Student student in course.GetEnrolledStudents())
    {
        Console.WriteLine(student.Name);
    }
}



