using CommunalServices.Core.Models;
using CommunalServices.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Location>> GetLocationsIncludeChildrenAsync()
        {
            return await context.Locations
                .Include(x => x.Children).ToListAsync();
        }
    }
}
