using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using UserManagement.Domain.Entities;

namespace UserManagement.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, string connectionString = null) : base(options)
        {
            _connectionString = connectionString;
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddMappingsDynamically(modelBuilder);
        }

        private static void AddMappingsDynamically(ModelBuilder modelBuilder)
        {
            var currentAssembly = typeof(ApplicationDbContext).Assembly;
            var efMappingTypes = currentAssembly.GetTypes().Where(t =>
                t.FullName.StartsWith("UserManagement.Infra.Data.Mappings.") &&
                t.FullName.EndsWith("Mapping"));

            foreach (var map in efMappingTypes.Select(Activator.CreateInstance))
            {
                modelBuilder.ApplyConfiguration((dynamic)map);
            }
        }
    }
}
