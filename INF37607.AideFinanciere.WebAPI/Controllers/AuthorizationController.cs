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

namespace EAISolutionFrontEnd.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AuthorizationController(IUserService userService, IConfiguration config, IMapper mapper)
        {
            _userService = userService;
            _config = config;
            _mapper = mapper;
        }

        [HttpPost("validate")]
        public async Task<IActionResult> Validate(UserForValidateDto userForValidateDto)
        {
            // ICI, il faudrait valider le NAS et sa correspondance avec la date de naissance
            // auprès d'une source de données authoritative (un service externe par exemple), et
            // retourner une erreur si la combinaison de données n'est pas valide.
            
            if (await _userService.GetUserByNas(userForValidateDto.SocialInsuranceNumber) != null)
                return BadRequest("L'étudiant existe déjà.");
            
            return Ok(true);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            // ICI, il faudrait valider le NAS et sa correspondance avec la date de naissance
            // auprès d'une source de données authoritative (un service externe par exemple), et
            // retourner une erreur si la combinaison de données n'est pas valide.
            
            if (await _userService.GetUserByNas(userForRegisterDto.SocialInsuranceNumber) != null)
                return BadRequest("User already exists");

            var userToCreate = _mapper.Map<User>(userForRegisterDto);

            Util util = new Util();
            userToCreate.PermanentCode =  util.GenerateUniqueRandomString(9);

            var createdUser = await _userService.RegisterUser(userToCreate);

            var userToReturn = _mapper.Map<UserForDetailedDto>(createdUser);
            return Ok(userToReturn);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _userService.AuthenticateUser(userForLoginDto.CodePermanent
                .ToLower(), userForLoginDto.Password);

             if (user == null)
                 return Unauthorized();
            
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.PermanentCode)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userToReturn = _mapper.Map<UserForListDto>(user);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                userToReturn
            });
        }

    }
}
