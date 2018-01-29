using CommunalServices.Core;
using CommunalServices.Core.Repositories;
using CommunalServices.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Utilities = new UtilityRepository(_context);
            Locations = new LocationRepository(_context);
            Providers = new ProviderRepository(_context);
        }

        public IUtilityRepository Utilities { get; private set; }
        public ILocationRepository Locations { get; private set; }
        public IProviderRepository Providers { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
