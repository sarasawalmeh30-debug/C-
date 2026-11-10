using System.ComponentModel.DataAnnotations;

namespace Request_Management_System8.Models
{
    public class LoginTDO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Erorr im Email ")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [EmailAddress(ErrorMessage = "Erorr im password ")]
        public string password { get; set; }
    }
}
