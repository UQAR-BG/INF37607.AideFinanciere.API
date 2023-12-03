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
using INF37607.AideFinanciere.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace EAISolutionFrontEnd.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly Random _random;
        private Request _request;
        
        public RequestController(IRequestService requestService, IUserService userService, IMapper mapper)
        {
            _requestService = requestService;
            _userService = userService;
            _mapper = mapper;
            _random = new Random();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCompletedRequests()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim is null)
                return BadRequest("This user does not exist.");
            
            var activeRequests = await _requestService.GetRequests(int.Parse(userIdClaim.Value)) ?? new List<Request>();

            var requestToReturn = _mapper.Map<List<RequestForDetailedDto>>(activeRequests);
          
            return Ok(requestToReturn);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveRequests()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim is null)
                return BadRequest("This user does not exist.");
            
            var activeRequests = await _requestService.GetAllActiveRequests(int.Parse(userIdClaim.Value)) ?? new List<Request>();

            var requestToReturn = _mapper.Map<List<RequestForDetailedDto>>(activeRequests);
          
            return Ok(requestToReturn);
        }

        [HttpPatch("save")]
        public async Task<IActionResult> SaveRequest(RequestForRegistereDto requestForRegisteredDto)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim is null)
                return BadRequest("This user does not exist.");

            var user = await _userService.GetUserById(int.Parse(userIdClaim.Value));
            
            var requestToCreate = _mapper.Map<Request>(requestForRegisteredDto);
            requestToCreate.User = user;
            requestToCreate.UserId = user.Id;
            requestToCreate.Status = FinancialAideStatus.Pending;

            await AddIfNewOrUpdateAsync(requestToCreate);

            return Ok();
        }

        [HttpPut("complete")]
        public async Task<IActionResult> CompleteRequest(RequestForRegistereDto requestForRegisteredDto)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim is null)
                return BadRequest("This user does not exist.");

            var user = await _userService.GetUserById(int.Parse(userIdClaim.Value));
            
            var requestToCreate = _mapper.Map<Request>(requestForRegisteredDto);
            requestToCreate.User = user;
            requestToCreate.UserId = user.Id;
            requestToCreate.Status = FinancialAideStatus.Completed;

            requestToCreate.FinancialAid = new FinancialAide()
            {
                PaymentDate = DateTime.Now,
                Type = _random.NextEnumValue<FinancialAideType>(),
                Amount = _random.Next(200, 5000)
            };

            await AddIfNewOrUpdateAsync(requestToCreate);
            
            return Ok();
        }
        
        [HttpPatch("cancel")]
        public async Task<IActionResult> CancelRequest()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim is null)
                return BadRequest("This user does not exist.");

            var activeRequests = await _requestService.GetAllActiveRequests(int.Parse(userIdClaim.Value));
            if (activeRequests == null || activeRequests.Count == 0)
                return Ok();
            
            var requestToCancel = activeRequests.First();
            requestToCancel.Status = FinancialAideStatus.Cancelled;
            
            await _requestService.UpdateRequest(requestToCancel);
            
            return Ok();
        }

        private async Task AddIfNewOrUpdateAsync(Request request)
        {
            if (_requestService.IsPending(request.UserId))
            {
                await _requestService.UpdateRequest(request);
            }
            else
            {
                await _requestService.AddRequest(request);
            }
        }
    }
}
