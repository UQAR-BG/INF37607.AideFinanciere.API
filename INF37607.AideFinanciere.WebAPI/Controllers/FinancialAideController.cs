using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EAISolutionFrontEnd.Core;
using EAISolutionFrontEnd.Core.Interfaces;
using EAISolutionFrontEnd.WebAPI.Dtos;
using INF37607.AideFinanciere.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace EAISolutionFrontEnd.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialAideController : ControllerBase
    {
        private readonly IFinancialAideService _financialAideService;
        private readonly IMapper _mapper;
        public FinancialAideController(IFinancialAideService financialAideService, IMapper mapper)
        {
            _financialAideService = financialAideService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClaims([FromQuery] FinancialAideStatus status = FinancialAideStatus.Completed)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim is null)
                return BadRequest("This user does not exist.");
            
            List<FinancialAide> financialAides = await _financialAideService.GetFinancialAides(int.Parse(userIdClaim.Value), status);

            if (financialAides == null)
                financialAides = new List<FinancialAide>();

            var financialAideToReturn = _mapper.Map<List<FinancialAideForDetailedDto>>(financialAides);

            return Ok(financialAideToReturn);
        }


        [HttpPost("PostFinancialAide")]
        public async Task<IActionResult> SendRequest(FinancialAideForRegisterDto financialAideForRegistereDto)
        {
            var financialAideToCreate = _mapper.Map<FinancialAide>(financialAideForRegistereDto);
            await _financialAideService.AddFinancialAide(financialAideToCreate);

            return Ok();
        }
    }
}
