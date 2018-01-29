using CommunalServices.Core.Models;
using CommunalServices.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunalServices.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(DbContext context) : base(context)
        {
        }
    }
}
