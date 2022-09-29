using HotelListing.API.Data;
using HotelListing.API.Interfaces;
using HotelListing.API.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthManager authManager, ILogger<AuthController> logger)
        {
            this._authManager = authManager;
            this._logger = logger;
        }

        //POST: api/Auth/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] UserDto apiUserDto)
        {
            _logger.LogInformation($"Registration attempt for {apiUserDto.Email}");

            var messages = await _authManager.Register(apiUserDto);

            if (messages.Any())
            {
                foreach (var message in messages)
                {
                    ModelState.AddModelError(message.Code, message.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();


        }

        //POST: api/Auth/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            _logger.LogInformation($"Login attemp for {loginDto.Email}");
            var authResponse = await _authManager.Login(loginDto);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }


        //POST: api/Auth/refreshtoken
        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto request)
        {
            var authResponse = await _authManager.VerifyRefreshToken(request);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }
    }
}
