using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MDM_Web.API.Helpers;
using MDM_Web.API.Infrastructure;
using MDM_Web.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model;

namespace MDM_Web.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly AppSettings _appSettings;
        

        public UserController(UserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("new")]
        public async Task<ActionResult> Create([FromForm] CreateUserViewModel createUserViewModel)
        {
            bool validUsername;
            var hashed = BCrypt.Net.BCrypt.HashPassword(createUserViewModel.Password);
            var user = new User(Guid.NewGuid(),createUserViewModel.UserName,hashed,DateTime.Now,createUserViewModel.Role);
            if (await _userRepository.Create(user))
            {
                return Ok();
            }

            return BadRequest();

        }
        
        
    }
}