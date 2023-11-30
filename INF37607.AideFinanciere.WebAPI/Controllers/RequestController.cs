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
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public RequestController(IRequestService requestService, IUserService userService, IMapper mapper)
        {
            _requestService = requestService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("getRequest")]
        public async Task<IActionResult> GetRequest(int userId)
        {
            Request request = await _requestService.GetRequest(userId);

            if (request == null)
                return BadRequest("This user doesn't have a pending request");

            var requestToReturn = _mapper.Map<RequestForDetailedDto>(request);
          
            return Ok(requestToReturn);
        }

        [HttpPost("requestRegistration")]
        public async Task<IActionResult> SendRequest(RequestForRegistereDto requestForRegisteredDto)
        {
            var requestToCreate = _mapper.Map<Request>(requestForRegisteredDto);
            await _requestService.AddRequest(requestToCreate);

            return Ok();
        }

        [HttpPost("udapteRequest")]
        public async Task<IActionResult> UdapteRequest(RequestForRegistereDto requestForRegisteredDto)
        {

            var requestToCreate = _mapper.Map<Request>(requestForRegisteredDto);
       
            await _requestService.UpdateRequest(requestToCreate);
            
            return Ok();
        }

        [HttpPost("deleteRequest")]
        public async Task<IActionResult> DeleteRequest(int userId)
        {
            Request request = await _requestService.GetRequest(userId);

            if (request == null)
                return BadRequest("This user doesn't have a pending request");

            await _requestService.DeleteRequest(request);

            return Ok();
        }

    }
}
