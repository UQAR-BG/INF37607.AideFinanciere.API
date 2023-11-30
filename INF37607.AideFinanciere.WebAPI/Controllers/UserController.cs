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


        [HttpGet("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo(int userId)
        {


            User user = await _userService.GetUserById(userId);

            if (user == null)
            {
                return BadRequest("This user dont exist.");
            }

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);

        }

        [HttpPost("updateUser")]
        public async Task<IActionResult> UdapteRequest(UserForUpdatedDto userForUpdatedDto)
        {

            var userToUpdate = _mapper.Map<User>(userForUpdatedDto);

            await _userService.UpdateUser(userToUpdate);

            return Ok();
        }
    }
}
