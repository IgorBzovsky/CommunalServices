using CommunalServices.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.Core.Repositories
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<Provider> GetProviderAsync(int id, bool includeRelated = true);
    }
}
