using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserLoginAttempt> UserLoginAttempts { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            //Database.EnsureDeleted();
        }
    }
}