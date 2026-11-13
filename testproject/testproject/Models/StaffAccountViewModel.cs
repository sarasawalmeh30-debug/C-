using System.ComponentModel.DataAnnotations;

namespace testproject.Models;

public class StaffAccountViewModel
{
    [Required, StringLength(150)] public string FullName { get; set; } = string.Empty;
    [Required, EmailAddress] public string Email { get; set; } = string.Empty;
    [Required] public string Role { get; set; } = string.Empty;
    [StringLength(100)] public string? JobTitle { get; set; }
    [Required, MinLength(10), DataType(DataType.Password)] public string TemporaryPassword { get; set; } = string.Empty;
}

public class StaffAccountRow
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string OnboardingStatus { get; set; } = string.Empty;
}
