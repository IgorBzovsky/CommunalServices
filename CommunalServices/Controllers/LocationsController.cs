using AutoMapper;
using CommunalServices.Controllers.Resources;
using CommunalServices.Core.Models;
using CommunalServices.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public LocationsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("/api/locations")]
        public async Task<IEnumerable<LocationResource>> GetLocations()
        {
            var locations = await _context.Locations
                .Include(x => x.Children).ToListAsync<Location>();
            var parentLocations = locations.Where(l => l.ParentId == null);
            return _mapper.Map<IEnumerable<Location>, IEnumerable<LocationResource>>(parentLocations);
        }
    }
}
