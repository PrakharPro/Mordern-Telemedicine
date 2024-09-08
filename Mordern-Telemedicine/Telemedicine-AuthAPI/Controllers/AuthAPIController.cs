using Microsoft.AspNetCore.Mvc;
using Telemedicine_AuthAPI.Models.Dto;
using Telemedicine_AuthAPI.Service.IService;

namespace Telemedicine_AuthAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthAPIController : Controller
    {
        private readonly IAuthService _authService;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestDto model)
        {
            var response = new ResponseDto();
            var user = await _authService.Login(model);
            if (user.User == null)
            {
                response.IsSuccess = false;
                response.Message = "Username or Password is incorrect";
                return BadRequest(response);
            }
            response.Result = user;
            return Ok(response);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationRequestDto)
        {
            var result = await _authService.Register(registrationRequestDto);
            var response = new ResponseDto();
            if (result.Equals(""))
            {
                return Ok(response);
            }
            else
            {
                response.IsSuccess = false;
                response.Message = result.ToString();
            }
            return BadRequest(response);
        }
    }
}
