using Entity1;
using Microsoft.EntityFrameworkCore;
using model;

namespace data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<Attendance>();

            base.OnModelCreating(modelBuilder);
        }
    }
}