using AutoMapper;
using CommunalServices.Controllers.Resources;
using CommunalServices.Core;
using CommunalServices.Core.Models;
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
        private readonly IUnitOfWork _unitOfWork;
        public ProvidersController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProvider([FromBody] SaveProviderResource providerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var provider = _mapper.Map<SaveProviderResource, Provider>(providerResource);
            _unitOfWork.Providers.Add(provider);
            await _unitOfWork.CompleteAsync();

            provider = await _unitOfWork.Providers.GetProviderAsync(provider.Id);
            var result = _mapper.Map<Provider, ProviderResource>(provider);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProvider(int id, [FromBody] SaveProviderResource providerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var provider = await _unitOfWork.Providers.GetProviderAsync(id);

            if (provider == null)
                return NotFound();

            _mapper.Map(providerResource, provider);
            await _unitOfWork.CompleteAsync();

            provider = await _unitOfWork.Providers.GetProviderAsync(id);
            var result = _mapper.Map<Provider, ProviderResource>(provider);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProvider(int id)
        {
            var provider = await _unitOfWork.Providers.GetProviderAsync(id);
            if (provider == null)
                return NotFound();
            var providerResource = _mapper.Map<Provider, ProviderResource>(provider);
            return Ok(providerResource);
        }
    }
}
