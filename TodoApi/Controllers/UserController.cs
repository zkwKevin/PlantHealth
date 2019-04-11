using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Service;
using AutoMapper;
using System;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace TodoApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase{
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(IUserManager userManager, IMapper mapper, IOptions<AppSettings> appSettings ){
            _userManager = userManager;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserViewModel userViewModel)
        {
            var user = _userManager.Authenticate(userViewModel.Name, userViewModel.Password);
            
            if(user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new {
                Id = user.Id,
                UserName = user.Name,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserViewModel userModel)
        {
            
            //map userViewModel to entity
            var user = _mapper.Map<User>(userModel);

            try
            {
                _userManager.Create(user, userModel.Password);
                return Ok();
            }
            catch(ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }

        [HttpGet]
        public IActionResult GetbyId(int id)
        {
            var user = _userManager.GetById(id);
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return Ok(userViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult EditProfile(int id, [FromBody]UserProfileViewModel userProfileModel)
        {
            var user = _mapper.Map<User>(userProfileModel);
            user.Id = id;
            try
            {
                _userManager.EditProfile(user.Id, user);
                return Ok();
            }
            catch(ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }
        
    }
}