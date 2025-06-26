namespace task02;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

public class Student
{
    public string Name { get; set; }
    public string Faculty { get; set; }
    public List<int> Grades { get; set; }
}
public class StudentService
{
    private readonly List<Student> _students;

    public StudentService(List<Student> students) => _students = students;

    public IEnumerable<Student> GetStudentsByFaculty(string faculty)
    {
        return _students.Where(student => student.Faculty.Equals(faculty));
    }

    public IEnumerable<Student> GetStudentsWithMinAverageGrade(double minAverageGrade)
    {
        return _students.Where(student => student.Grades.Average() >= minAverageGrade);
    }

    public IEnumerable<Student> GetStudentsOrderedByName()
    {
        return _students.OrderBy(student => student.Name);
    }

    public ILookup<string, Student> GroupStudentsByFaculty()
    {
        return _students.ToLookup(student => student.Faculty);
    }
    public string GetFacultyWithHighestAverageGrade()
    {
        return _students
            .Where(student => student.Grades.Any())
            .GroupBy(student => student.Faculty)
            .Select(group => new
            {
                Faculty = group.Key,
                AverageGrade = group.Average(student => student.Grades.Average())
            })
            .OrderByDescending(faculty => faculty.AverageGrade)
            .FirstOrDefault()?.Faculty;
    }
};
