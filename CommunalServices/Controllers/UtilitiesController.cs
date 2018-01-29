using AutoMapper;
using CommunalServices.Controllers.Resources;
using CommunalServices.Core.Models;
using CommunalServices.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Controllers
{
    [Route("/api/[controller]")]
    public class UtilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UtilitiesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<KeyValuePairResource>> GetUtilities()
        {
            var utilities = await _context.Utilities.ToListAsync();
            return _mapper.Map<IEnumerable<Utility>, IEnumerable<KeyValuePairResource>>(utilities);
        }
    }
}
