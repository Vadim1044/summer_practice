namespace test13tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using task13;

public class tests
{
    public JsonSerializerOptions options;
    public tests()
    {
        options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new CustomDateTimeConverter() }
        };
    }
    [Fact]
    public void Serialize_TestNullAndFormatData()
    {
        Student student = new Student
        {
            Grades = new List<Subject>
            {
                new Subject { Name = "Economic", Grade = 3}
            },
            BirthDate = new DateTime(2005, 3, 15),
            LastName = "kek"
        };
        string objectSerialized = JsonSerializer.Serialize(student, options);
        Assert.Contains("15-03-2005", objectSerialized);
        Assert.Contains("kek", objectSerialized);
        Assert.Contains("Economic", objectSerialized);
        Assert.DoesNotContain("FisrtName", objectSerialized);   
    }
    [Fact]
    public void Deserialise_test()
    {
        Student student = new Student
        {
            Grades = new List<Subject>
            {
                new Subject { Name = "Economic", Grade = 3}
            },
            BirthDate = new DateTime(2005, 3, 15),
            LastName = "kek"
        };
        string objectSerialized = JsonSerializer.Serialize(student, options);
        var objectDeserialized = JsonSerializer.Deserialize<Student>(objectSerialized, options);

        Assert.Contains("15-03-2005", objectSerialized);
        Assert.Contains("kek", objectSerialized);
        Assert.Contains("Economic", objectSerialized);
        Assert.DoesNotContain("FisrtName", objectSerialized);
    }
}