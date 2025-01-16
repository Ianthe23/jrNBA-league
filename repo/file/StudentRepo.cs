

public class StudentRepo : InFileRepo<int, Student>
{
    public StudentRepo(string filePath) : base(filePath, LineToStudent, StudentToLine)
    {
        
    }

    public static Student LineToStudent(string line)
    {
        var fields = line.Split(",");
        return new Student
        {
            Id = int.Parse(fields[0]),
            Name = fields[1],
            School = fields[2]
        };
    }

    public static string StudentToLine(Student student)
    {
        return $"{student.Id},{student.Name},{student.School}";
    }
}