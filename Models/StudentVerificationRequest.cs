using System.ComponentModel.DataAnnotations;

public class StudentVerificationRequest
{
    [Required]
    public string StudentId { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public StudentVerificationRequest(string studentId, string firstName, string lastName)
    {
        StudentId = studentId;
        FirstName = firstName;
        LastName = lastName;
    }
}
