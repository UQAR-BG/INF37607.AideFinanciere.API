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
using INF37607.AideFinanciere.WebAPI;
using Microsoft.AspNetCore.Authorization;
using EAISolutionFrontEnd.Core.Services;

namespace EAISolutionFrontEnd.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserController(IUserService userService, IConfiguration config, IMapper mapper)
        {
            _userService = userService;
            _config = config;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetInfo()
        {
            var codePermanentClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (codePermanentClaim is null)
                return BadRequest("This user does not exist.");
            
            User user = await _userService.GetUserByCodePermanent(codePermanentClaim.Value);

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);

        }

        [HttpPatch]
        public async Task<IActionResult> Update(UserForUpdatedDto userForUpdatedDto)
        {
            var codePermanentClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (codePermanentClaim is null)
                return BadRequest("This user does not exist.");

            userForUpdatedDto.Id = Int32.Parse(codePermanentClaim.Value);
            User userToUpdate = _mapper.Map<User>(userForUpdatedDto);

            userToUpdate = await _userService.UpdateUser(userToUpdate);

            return Ok(userToUpdate);
        }
    }
}
