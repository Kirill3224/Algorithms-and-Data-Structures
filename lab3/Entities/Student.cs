namespace lab3.Entities;

public class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int Course { get; set; }
    public uint StudentTicket { get; set; }
    public string Gender { get; set; }
    public string Residence { get; set; }

    public Student(string lastName, string firstName, int course, uint studentTicket, string gender, string residence)
    {
        LastName = lastName;
        FirstName = firstName;
        Course = course;
        StudentTicket = studentTicket;
        Gender = gender;
        Residence = residence;
    }

    public override string ToString()
    {
        return $"| {StudentTicket,-10} | {LastName,-10} | {FirstName,-10} | {Course,-4} | {Gender,-7} | {Residence,-15} |";
    }
}