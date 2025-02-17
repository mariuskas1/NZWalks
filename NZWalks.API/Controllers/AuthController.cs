using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.Username,
                Email = registerRequestDTO.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDTO.Password);

            if (identityResult.Succeeded) 
            {
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any()) 
                {
                   identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered.");
                    }
                }
            }

            return BadRequest();

        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDTO.UserName);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

                if(checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    if(roles != null)
                    {
                        var jwtToken = tokenRepository.CreateJwtToken(user, roles.ToList());
                        
                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken,
                        };

                        return Ok(jwtToken);
                    }
                }
            }

            return BadRequest("Username or Password incorrect.");
        }
    }
}
