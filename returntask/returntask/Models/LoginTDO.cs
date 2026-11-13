using System.ComponentModel.DataAnnotations;

namespace returntask.Models
{
    public class LoginTDO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
