﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CommunalServices.Core.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Location Parent { get; set; }
        public ICollection<Location> Children { get; set; }

        public Location()
        {
            Children = new Collection<Location>();
        }
    }
}
