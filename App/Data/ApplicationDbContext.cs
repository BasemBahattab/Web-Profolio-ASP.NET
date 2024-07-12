using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Profolio_ASP.NET_MVC.Models;

namespace Profolio_ASP.NET_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Profolio_ASP.NET_MVC.Models.AboutMe> AboutMe { get; set; } = default!;
        public DbSet<Profolio_ASP.NET_MVC.Models.myProject> myProject { get; set; } = default!;
    }
}
