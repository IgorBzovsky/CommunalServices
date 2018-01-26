using CommunalServices.Core.Models;
using CommunalServices.Persistance.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Utility> Utilities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<ProvidedUtility>(new ProvidedUtilityConfiguration());
        }
    }
}
