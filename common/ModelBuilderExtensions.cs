using System.Reflection;
using Microsoft.EntityFrameworkCore;
using model;

namespace Common.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddEntitiesFromAssembly(this ModelBuilder modelBuilder, Type assemblyType)
        {
            var entities = assemblyType.Assembly.GetExportedTypes()
                .Where(p => !p.IsAbstract && p.IsClass && p.IsSubclassOf(typeof(IBaseEntity)) &&
                            typeof(IBaseEntity).IsAssignableFrom(p));
            foreach (var entity in entities)
            {
                modelBuilder.Entity(entity);
            }
        }
    }
}