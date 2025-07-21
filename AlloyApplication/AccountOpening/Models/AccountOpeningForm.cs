using System.ComponentModel.DataAnnotations;

namespace AccountOpening.Models
{
    public class AccountOpeningForm
    {
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    [Required]
    public string? City { get; set; }
    [Required]
    [RegularExpression("^[A-Z]{2}$", ErrorMessage = "State must be a two-letter code.")]
    public string? State { get; set; }
    [Required]
    public string? ZipCode { get; set; }
    [Required]
    [RegularExpression("^US$", ErrorMessage = "Country must be US.")]
    public string? Country { get; set; } = "US";
    [Required]
    [RegularExpression("^[0-9]{9}$", ErrorMessage = "SSN must be 9 digits.")]
    public string? SSN { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [RegularExpression("^\\d{4}-\\d{2}-\\d{2}$", ErrorMessage = "Date of Birth must be YYYY-MM-DD.")]
    public string? DateOfBirth { get; set; }
    }
}
