using System.ComponentModel.DataAnnotations;

namespace CodeFirstEFinAsp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email id")]
        [EmailAddress(ErrorMessage ="enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Enter your age")]
        [Range(0,100, ErrorMessage ="Please enter your age between 1 to 100 only")]
        public int Age {  get; set; }
    }
}
