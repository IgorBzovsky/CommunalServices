using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Controllers.Resources
{
    public class LocationResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<LocationResource> Children { get; set; }

        public LocationResource()
        {
            Children = new Collection<LocationResource>();
        }
    }
}
