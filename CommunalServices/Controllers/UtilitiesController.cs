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
    public class UtilitiesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UtilitiesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<KeyValuePairResource>> GetUtilities()
        {
            var utilities = await _unitOfWork.Utilities.GetAllAsync();
            return _mapper.Map<IEnumerable<Utility>, IEnumerable<KeyValuePairResource>>(utilities);
        }
    }
}
