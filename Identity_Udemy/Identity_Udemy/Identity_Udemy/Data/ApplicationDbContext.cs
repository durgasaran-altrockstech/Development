using Identity_Udemy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity_Udemy.Data
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext (DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
    }
}
