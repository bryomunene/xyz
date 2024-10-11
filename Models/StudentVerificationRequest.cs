using System.ComponentModel.DataAnnotations;

public class StudentVerificationRequest
{
    [Required]
    public string StudentId { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
}
