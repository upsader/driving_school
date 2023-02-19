using API.Dtos.Users;
using API.Helpers;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized();

            return new UserDto(user, _tokenService.CreateToken(user));
            
        }

        [Authorize(Role.Admin)]
        [HttpPost("create")]
        public async Task<ActionResult<UserDto>> CreateUser(CreateDto createDto)
        {
            var user = new User()
            {
                UserName = createDto.Username,
                Email = createDto.Email,
                Role = createDto.Role
            };

            var result = await _userManager.CreateAsync(user, createDto.Password);

            if (!result.Succeeded) return BadRequest();

            return new UserDto(user, _tokenService.CreateToken(user));
        }

        [Authorize(Role.Admin)]
        [HttpDelete("delete")]
        public async Task<ActionResult<UserDto>> DeleteUser(string email)
        {

            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return Ok();
        }

        [Authorize(Role.Admin)]
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var result = new List<UserDto>();
            if (users != null)
            {
                foreach (var user in users)
                {
                    result.Add(new UserDto(user));
                }
            }

            return Ok(result);
        }
    }
}
