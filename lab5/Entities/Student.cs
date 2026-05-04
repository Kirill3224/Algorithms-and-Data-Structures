namespace lab5.Entities;

public class Student : IComparable<Student>
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int Course { get; set; }
    public string Group { get; set; }
    public string City { get; set; }

    public Student(string lastName, string firstName, int course, string group, string city)
    {
        LastName = lastName;
        FirstName = firstName;
        Course = course;
        Group = group;
        City = city;
    }

    public int CompareTo(Student other)
    {
        return string.Compare(this.LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"| {LastName,-12} | {FirstName,-10} | {Course,-4} | {Group,-8} | {City,-12} |";
    }
}