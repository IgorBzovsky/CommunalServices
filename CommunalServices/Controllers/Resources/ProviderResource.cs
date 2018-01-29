using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Controllers.Resources
{
    public class ProviderResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationResource Location { get; set; }
        public ICollection<UtilityResource> ProvidedUtilities { get; set; }

        public ProviderResource()
        {
            ProvidedUtilities = new Collection<UtilityResource>();
        }
    }
}
