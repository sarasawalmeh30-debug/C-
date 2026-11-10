
using System.ComponentModel.DataAnnotations;

namespace Request_Management_System8.Models
{
    public class RegisterTDO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Enter correct Email ")]
        public string Email { get; set; }
       
        [Required]
        [MinLength(8, ErrorMessage = "Must passwoed 8 character at lest")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(password))]
        [EmailAddress(ErrorMessage = "The password is not match ")]
        public string comfpassword { get; set; }
    }
}
