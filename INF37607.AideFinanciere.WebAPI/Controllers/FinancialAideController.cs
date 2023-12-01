using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EAISolutionFrontEnd.Core;
using EAISolutionFrontEnd.Core.Interfaces;
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
        private readonly IMapper _mapper;
        public FinancialAideController(IFinancialAideService financialAideService, IMapper mapper)
        {
            _financialAideService = financialAideService;
            _mapper = mapper;
        }

        [HttpGet("getFinancialAide")]
        public async Task<IActionResult> GetRequest(int userId)
        {
            List<FinancialAide> financialAides = await _financialAideService.GetFinancialAides(userId);

            if (financialAides == null || financialAides.Count == 0)
                return NoContent();

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
