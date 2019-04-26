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
using System.Collections.Generic;

namespace TodoApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase{
        private readonly IUserManager _userManager;
        private readonly ITargetItemManager _targetItemManager;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(IUserManager userManager, IMapper mapper, IOptions<AppSettings> appSettings, ITargetItemManager targetItemManager ){
            _userManager = userManager;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _targetItemManager = targetItemManager;
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserViewModel userViewModel)
        {
            var user = _userManager.Authenticate(userViewModel.Username, userViewModel.Password);
            Console.WriteLine(userViewModel.Username , userViewModel.Password);
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
                Username = user.Username,
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
            catch(AppException ex)
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

        
        [HttpPut("profile/{id}")]
        public IActionResult EditProfile(int id, [FromBody]UserProfileViewModel userProfileModel)
        {
            var user = _mapper.Map<User>(userProfileModel);
            user.Id = id;
            try
            {
                _userManager.EditProfile(user);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }

       
        [HttpPut("privacy/{id}")]
        public IActionResult UpdatePrivacy(int id, [FromBody]UserViewModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            user.Id = id;
            try
            {
                _userManager.UpdatePrivacy(user, userModel.Password);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }       
    }
}