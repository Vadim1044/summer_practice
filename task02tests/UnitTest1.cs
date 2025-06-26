using task02;
using Xunit;
using System.Collections.Generic;
using System.Linq;
public class StudentServiceTests
{
    private List<Student> _testStudents;
    private StudentService _service;

    public StudentServiceTests()
    {
        _testStudents = new List<Student>
            {
                new Student { Name = "Иван", Faculty = "ФИТ", Grades = new List<int> { 5, 4, 5 } },
                new Student { Name = "Анна", Faculty = "ФИТ", Grades = new List<int> { 3, 4, 3 } },
                new Student { Name = "Петр", Faculty = "Экономика", Grades = new List<int> { 5, 5, 5 } }
            };
        _service = new StudentService(_testStudents);
    }

    [Fact]
    public void GetStudentsByFaculty_ReturnsCorrectStudents()
    {
        var result = _service.GetStudentsByFaculty("ФИТ").ToList();
        Assert.Equal(2, result.Count);
        Assert.True(result.All(student => student.Faculty == "ФИТ"));
    }

    [Fact]
    public void GetStudentAverageGrade_ReturnsCorrectStudents()
    {
        var result = _service.GetStudentsWithMinAverageGrade(3.5);
        Assert.True(result.All(student => student.Grades.Average() >= 3.5));
    }
    [Fact]
    public void GetStudentsOrderedByName_ReturnsOrderedNames()
    {
        var result = _service.GetStudentsOrderedByName().ToList();
        Assert.True(result[0].Name == "Анна");
        Assert.True(result[1].Name == "Иван");
        Assert.True(result[2].Name == "Петр");
    }
    [Fact]
    public void GroupStudentsByFaculty_ReturnsGroupStudents()
    {
        var result = _service.GroupStudentsByFaculty();
        Assert.True(2 == result["ФИТ"].Count());
        Assert.True(1 == result["Экономика"].Count());
    }

    [Fact]
    public void GetFacultyWithHighestAverageGrade_ReturnsCorrectFaculty()
    {
        var result = _service.GetFacultyWithHighestAverageGrade();
        Assert.True("Экономика" == result);
    }
}
