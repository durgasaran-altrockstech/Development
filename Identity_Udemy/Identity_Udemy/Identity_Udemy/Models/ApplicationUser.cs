using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Identity_Udemy.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        public String Name { get; set; }
    }
}
