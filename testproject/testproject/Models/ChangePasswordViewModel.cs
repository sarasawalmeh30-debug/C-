using System.ComponentModel.DataAnnotations;

namespace testproject.Models;

public class ChangePasswordViewModel
{
    [Required, DataType(DataType.Password)] public string CurrentPassword { get; set; } = string.Empty;
    [Required, MinLength(10), DataType(DataType.Password)] public string NewPassword { get; set; } = string.Empty;
    [Required, Compare(nameof(NewPassword)), DataType(DataType.Password)] public string ConfirmPassword { get; set; } = string.Empty;
}
