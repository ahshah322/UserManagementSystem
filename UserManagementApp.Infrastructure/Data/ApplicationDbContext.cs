using Microsoft.EntityFrameworkCore;
using UserManagementApp.Domain.Entities;

namespace UserManagementApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
