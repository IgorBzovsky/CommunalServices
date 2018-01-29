using CommunalServices.Core.Models;
using CommunalServices.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunalServices.Data.Repositories
{
    public class UtilityRepository : Repository<Utility>, IUtilityRepository
    {
        public UtilityRepository(DbContext context) : base(context)
        {
        }
    }
}
