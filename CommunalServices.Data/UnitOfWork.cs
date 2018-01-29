using CommunalServices.Core;
using CommunalServices.Core.Repositories;
using CommunalServices.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunalServices.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
            Utilities = new UtilityRepository(_context);
            Locations = new LocationRepository(_context);
        }

        public IUtilityRepository Utilities { get; private set; }
        public ILocationRepository Locations { get; private set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
