using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace task13;

public class Subject
{
    public string Name { get; set; }
    public int Grade { get; set; }
}

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<Subject> Grades { get; set; }

    public void WriteDown()
    {
        var student_file = new Student();
        string objectSerialized = JsonSerializer.Serialize(student_file);
        File.WriteAllText("Students.json",  objectSerialized);
    }

}

public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    private const string format = "dd-MM-yyyy";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var temp = reader.GetString();
        return DateTime.ParseExact(temp, format, null);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        var kek = value.ToString(format);
        writer.WriteStringValue(kek);
    }
}