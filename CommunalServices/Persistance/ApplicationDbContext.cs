using CommunalServices.Core.Models;
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
    }
}
