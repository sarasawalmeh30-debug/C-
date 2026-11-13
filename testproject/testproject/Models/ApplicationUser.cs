using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace testproject.Models;

public class ApplicationUser : IdentityUser
{
    [Required, StringLength(150)] public string FullName { get; set; } = string.Empty;
    // Public Identity registration is for suppliers. Admin-created staff accounts set this to Employee.
    [Required, StringLength(20)] public string UserType { get; set; } = "Supplier";
    [StringLength(100)] public string? JobTitle { get; set; }
    public int? DepartmentId { get; set; }
    public bool IsActive { get; set; } = true;
    public bool MustChangePassword { get; set; }
    [StringLength(30)] public string OnboardingStatus { get; set; } = "NotStarted";
    public DateTime? OnboardingCompletedAt { get; set; }
    public bool FingerprintDemoCompleted { get; set; }
    public bool FaceDemoCompleted { get; set; }
    public DateTime? BiometricDemoConsentAt { get; set; }
}

public class EmployeeProfile
{
    public int Id { get; set; }
    [Required] public string UserId { get; set; } = string.Empty;
    [Required, StringLength(30)] public string EmployeeNumber { get; set; } = string.Empty;
    [DataType(DataType.Date)] public DateTime HireDate { get; set; }
    [Required, StringLength(30)] public string WorkPhone { get; set; } = string.Empty;
    [Required, StringLength(10)] public string PreferredLanguage { get; set; } = "en";
    public string? ProfilePhotoPath { get; set; }
    public string? SignaturePath { get; set; }
    public DateTime? OnboardingCompletedAt { get; set; }
}

public class SupplierProfile
{
    public int Id { get; set; }
    [Required] public string UserId { get; set; } = string.Empty;
    [Required, StringLength(200)] public string CompanyName { get; set; } = string.Empty;
    [Required, StringLength(50)] public string TaxNumber { get; set; } = string.Empty;
    [Required, StringLength(50)] public string CommercialRegNumber { get; set; } = string.Empty;
    [Required, StringLength(80)] public string Country { get; set; } = string.Empty;
    [Required, StringLength(80)] public string City { get; set; } = string.Empty;
    [Required, StringLength(300)] public string Address { get; set; } = string.Empty;
    [Required, StringLength(150)] public string ContactPerson { get; set; } = string.Empty;
    [Required, StringLength(30)] public string ContactPhone { get; set; } = string.Empty;
    [StringLength(200)] public string? Website { get; set; }
    [Required, StringLength(100)] public string Category { get; set; } = string.Empty;
    [Required, StringLength(20)] public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
