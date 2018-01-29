using AutoMapper;
using CommunalServices.Controllers.Resources;
using CommunalServices.Core;
using CommunalServices.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Controllers
{
    public class LocationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LocationsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("/api/locations")]
        public async Task<IEnumerable<KeyValuePairResource>> GetLocations()
        {
            var locations = await _unitOfWork.Locations.GetLocationsIncludeChildrenAsync();
            var parentLocations = locations.Where(l => l.ParentId == null);
            return _mapper.Map<IEnumerable<Location>, IEnumerable<KeyValuePairResource>>(parentLocations);
        }

        [HttpGet("/api/regions")]
        public async Task<IEnumerable<KeyValuePairResource>> GetRegions()
        {
            var regions = await _unitOfWork.Locations.FindAsync(x => x.ParentId == null);
            return _mapper.Map<IEnumerable<Location>, IEnumerable<KeyValuePairResource>>(regions);
        }
    }
}
