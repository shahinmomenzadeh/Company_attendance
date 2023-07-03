using Microsoft.EntityFrameworkCore;
using model;
using System.Reflection;

namespace data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Get all types that implement IBaseEntity interface
            var entityTypes = Assembly.GetAssembly(typeof(IBaseEntity)).GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IBaseEntity).IsAssignableFrom(t));

            // Iterate over each entity type and add it to the model
            foreach (var entityType in entityTypes)
            {
                modelBuilder.Entity(entityType);
            }

            // Define the relationship between Employee and Attendance
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Attendances) // An employee can have many attendances
                .WithOne(a => a.Employee)   // An attendance belongs to one employee
                .HasForeignKey(a => a.EmployeeId); // The foreign key is EmployeeId
        }
    }
}