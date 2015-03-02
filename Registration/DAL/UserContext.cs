using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Registration.Models;

namespace Registration.DAL
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("Default")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Location> Locations { get; set; } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                HasMany(c => c.Services).
                WithMany(p => p.Users).
                Map(
                    m =>
                    {
                        m.MapLeftKey("UserId");
                        m.MapRightKey("ServiceId");
                        m.ToTable("UserServices");
                    });
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}