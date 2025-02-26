using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZwalks.Api.Models.DTO;
using NZwalks.Api.Repostries;

namespace NZwalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _manager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> manager, ITokenRepository tokenRepository)
        {
            _manager = manager;
            _tokenRepository = tokenRepository;
        }
            

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequestDTO registerRequestDTO)
        {

            var IdentityUser = new IdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.UserName
            };
            var IdentityResult = await _manager.CreateAsync(IdentityUser, registerRequestDTO.Password);
            if (IdentityResult.Succeeded)
            {
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    IdentityResult = await _manager.AddToRolesAsync(IdentityUser, registerRequestDTO.Roles);

                    if (IdentityResult.Succeeded)
                    {
                        return Ok("User Register Successed! Go To Login.");
                    }
                }
            }
            return BadRequest("Something Wrong !");
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var User = await _manager.FindByEmailAsync(loginRequestDTO.UserName);
            if (User != null)
            {
                var ChackPassword = await _manager.CheckPasswordAsync(User, loginRequestDTO.Password);
                if (ChackPassword)
                {
                    var Roles = await _manager.GetRolesAsync(User);
                    if (Roles != null)
                    {
                        var JwtTokeen = _tokenRepository.CreateToken(User, Roles.ToList());
                        var response = new LoginResponseDTO 
                        { 
                              JwtToken = JwtTokeen,
                        };

                        return Ok(response);
                    }



                }
            }

            return BadRequest("User Name or Password Incrorrect");

        }
    }
}















