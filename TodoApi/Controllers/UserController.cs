using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using TodoApi.Service;
using TodoApi.Resources;
using AutoMapper;
using System;

namespace TodoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase{
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public UserController(IUserManager userManager, IMapper mapper){
            _userManager = userManager;
            _mapper = mapper;
        }
        
        // [AllowAnonymous]
        // [HttpPost("authenticate")]
        // public IActionResult Authenticate([FromBody]User userParam)
        // {
        //     var user = _userManager.Authenticate(userParam.Name, userParam.Password);
        //     if(user == null)
        //         return BadRequest(new { message = "Username or password is incorrect" });
        //     return Ok(user);
        // }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegistrationViewModel userModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //transfer the data get from viewModel to Model
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

        
        
    }
}