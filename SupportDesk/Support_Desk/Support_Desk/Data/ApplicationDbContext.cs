using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Support_Desk.Models;

namespace Support_Desk.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions Options) : base(Options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
