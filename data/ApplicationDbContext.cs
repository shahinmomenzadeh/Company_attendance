using Microsoft.EntityFrameworkCore;
using model;
using System;
using Common.Extensions;
using Microsoft.EntityFrameworkCore.Diagnostics;

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

            modelBuilder.AddEntitiesFromAssembly<IBaseEntity>(typeof(IBaseEntity));
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IBaseEntity).Assembly);
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.AmbientTransactionWarning));
        }
    }
}