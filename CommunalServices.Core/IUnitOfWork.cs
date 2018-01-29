using CommunalServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunalServices.Core
{
    public interface IUnitOfWork
    {
        IUtilityRepository Utilities { get; }
        ILocationRepository Locations { get; }
        void Complete();
    }
}
