namespace lab4.Entities;

public class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Discipline { get; set; }
    public int LabCount { get; set; }

    public Student(string lastName, string firstName, string discipline, int labCount)
    {
        LastName = lastName;
        FirstName = firstName;
        Discipline = discipline;
        LabCount = labCount;
    }

    public override string ToString()
    {
        return $"| {LastName,-12} | {FirstName,-10} | {Discipline,-20} | {LabCount,-10} |";
    }
}