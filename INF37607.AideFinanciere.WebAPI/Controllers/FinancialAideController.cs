using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EAISolutionFrontEnd.Core;
using EAISolutionFrontEnd.Core.Interfaces;
using EAISolutionFrontEnd.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using EAISolutionFrontEnd.WebAPI.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace EAISolutionFrontEnd.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialAideController : ControllerBase
    {
        private readonly IFinancialAideService _financialAideService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public FinancialAideController(IFinancialAideService financialAideService, IUserService userService, IMapper mapper)
        {
            _financialAideService = financialAideService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("getFinancialAide")]
        public async Task<IActionResult> GetRequest(int userId)
        {
            List<FinancialAide> financialAide = await _financialAideService.GetFinancialAides(userId);

            if (financialAide == null)
                return BadRequest("This user doesn't have a pending request");

            var FinancialToReturn = _mapper.Map<FinancialForDetailedDto>(financialAide);
          
            return Ok(FinancialToReturn);
        }


    }
}
