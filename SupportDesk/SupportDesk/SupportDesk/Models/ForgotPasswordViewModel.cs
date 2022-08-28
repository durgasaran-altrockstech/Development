using System.ComponentModel.DataAnnotations;

namespace SupportDesk.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
