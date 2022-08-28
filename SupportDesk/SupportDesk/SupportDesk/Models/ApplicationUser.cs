using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SupportDesk.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String Module { get; set; }
 
    }
}
