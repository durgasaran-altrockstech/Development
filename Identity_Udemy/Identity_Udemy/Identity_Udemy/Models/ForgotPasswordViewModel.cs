using System.ComponentModel.DataAnnotations;

namespace Identity_Udemy.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
