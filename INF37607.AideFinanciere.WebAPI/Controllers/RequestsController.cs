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
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public RequestsController(IRequestService requestService, IUserService userService, IMapper mapper)
        {
            _requestService = requestService;
            _userService = userService;
            _mapper = mapper;
        }


        [HttpGet("UserRequests/{id}")]
        public async Task<IActionResult> GetUserRequests(int id)
        {
            var requests = await _requestService.GetUserRequests(id);

            var requestsToReturn = _mapper.Map<IEnumerable<RequestForListDto>>(requests);

            return Ok(requestsToReturn);
        }


        [HttpGet("RequestItems/{id}")]
        public async Task<IActionResult> GetRequestItems(int id)
        {
            var requestItems = await _requestService.GetRequestItems(id);

            var requestItemsToReturn = _mapper.Map<IEnumerable<RequestItemForListDto>>(requestItems);

            return Ok(requestItemsToReturn);
        }

        [HttpPost("NewUserRequest/{userId}")]
        public async Task<IActionResult> AddRequest(int userId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null) return BadRequest("User not found");
            var request = new Request(user);
            request = await _requestService.AddRequest(request);
            var requestToReturn = _mapper.Map<RequestForListDto>(request);
            return Ok(requestToReturn);
        }

        [HttpPost("NewRequestItem/{requestId}")]
        public async Task<IActionResult> AddRequestItem(int requestId, RequestItemForCreateDto requestItemForCreateDto)
        {
            var request = await _requestService.GetRequest(requestId);
            if (request == null) return BadRequest("Request not found");
            var requestItemToCreate = _mapper.Map<RequestItem>(requestItemForCreateDto);
            var requestUpdated = await _requestService.AddRequestItem(requestId, requestItemToCreate);
            var requestToReturn = _mapper.Map<RequestForDetailedDto>(requestUpdated);
            return Ok(requestToReturn);
        }

        [HttpDelete("RemovalRequestItem/{requestId}/{requestItemId}")]
        public async Task<IActionResult> DeleteRequestItem(int requestId, int requestItemId)
        {
            var request = await _requestService.GetRequest(requestId);
            if (request == null) return BadRequest("Request not found");
            var requestUpdated = await _requestService.DeleteRequestItem(requestId, requestItemId);
            var requestToReturn = _mapper.Map<RequestForDetailedDto>(requestUpdated);
            return Ok(requestToReturn);
        }

        [HttpPut("SubmissionRequest/{requestId}")]
        public async Task<IActionResult> SubmitRequest(int requestId, string directory)
        {
            var request = await _requestService.GetRequest(requestId);
            if (request == null) return BadRequest("Request not found");
            var requestUpdated = await _requestService.SubmitRequest(request, directory);
            var requestToReturn = _mapper.Map<RequestForDetailedDto>(requestUpdated);
            return Ok(requestToReturn);
        }


    }
}
