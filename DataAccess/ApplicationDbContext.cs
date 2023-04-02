using Kotabko.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kotabko.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> books { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Author> authors { get; set; }

    }
}
