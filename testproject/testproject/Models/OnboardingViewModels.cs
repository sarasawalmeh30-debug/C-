using System.ComponentModel.DataAnnotations;

namespace testproject.Models;

public class EmployeeProfileViewModel
{
    [Required, StringLength(150)] public string FullName { get; set; } = string.Empty;
    [Required, StringLength(30)] public string EmployeeNumber { get; set; } = string.Empty;
    [Required, DataType(DataType.Date)] public DateTime HireDate { get; set; } = DateTime.Today;
    [Required, Phone, StringLength(30)] public string WorkPhone { get; set; } = string.Empty;
    [Required] public string PreferredLanguage { get; set; } = "en";
}

public class SupplierProfileViewModel
{
    [Required, StringLength(150)] public string FullName { get; set; } = string.Empty;
    [Required, StringLength(200)] public string CompanyName { get; set; } = string.Empty;
    [Required, StringLength(50)] public string TaxNumber { get; set; } = string.Empty;
    [Required, StringLength(50)] public string CommercialRegNumber { get; set; } = string.Empty;
    [Required, StringLength(80)] public string Country { get; set; } = string.Empty;
    [Required, StringLength(80)] public string City { get; set; } = string.Empty;
    [Required, StringLength(300)] public string Address { get; set; } = string.Empty;
    [Required, StringLength(150)] public string ContactPerson { get; set; } = string.Empty;
    [Required, Phone, StringLength(30)] public string ContactPhone { get; set; } = string.Empty;
    [Url, StringLength(200)] public string? Website { get; set; }
    [Required, StringLength(100)] public string Category { get; set; } = string.Empty;
}

public class FingerprintDemoViewModel
{
    [Required, StringLength(80)] public string DeviceName { get; set; } = "My device";
}
