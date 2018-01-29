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
    public class ProvidersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ProvidersController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProvider([FromBody] SaveProviderResource providerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var provider = _mapper.Map<SaveProviderResource, Provider>(providerResource);
            _context.Add(provider);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Provider, SaveProviderResource>(provider);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProvider(int id, [FromBody] SaveProviderResource providerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var provider = await _context.Providers.Include(p => p.ProvidedUtilities).SingleOrDefaultAsync(x => x.Id == id);
            if (provider == null)
                return NotFound();
            _mapper.Map(providerResource, provider);
            _context.Add(provider);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Provider, SaveProviderResource>(provider);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProvider(int id)
        {
            var provider = await _context.Providers
                .Include(p => p.ProvidedUtilities)
                    .ThenInclude(u => u.Utility)
                .Include(p => p.Location)
                .SingleOrDefaultAsync(x => x.Id == id);
            if (provider == null)
                return NotFound();
            var providerResource = _mapper.Map<Provider, ProviderResource>(provider);
            return Ok(providerResource);
        }
    }
}
