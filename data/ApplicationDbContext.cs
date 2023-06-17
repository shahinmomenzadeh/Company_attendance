using Entity1;
using Microsoft.EntityFrameworkCore;
using model;

namespace data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
}