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
        public async Task<IEnumerable<KeyValuePairResource>> GetLocations()
        {
            var locations = await _context.Locations
                .Include(x => x.Children).ToListAsync();
            var parentLocations = locations.Where(l => l.ParentId == null);
            return _mapper.Map<IEnumerable<Location>, IEnumerable<KeyValuePairResource>>(parentLocations);
        }

        [HttpGet("/api/regions")]
        public async Task<IEnumerable<KeyValuePairResource>> GetRegions()
        {
            var regions = await _context.Locations
                .Where(x => x.ParentId == null).ToListAsync();
            return _mapper.Map<IEnumerable<Location>, IEnumerable<KeyValuePairResource>>(regions);
        }
    }
}
