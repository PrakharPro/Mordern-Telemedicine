using Microsoft.AspNetCore.Identity.Data;
using Telemedicine_AuthAPI.Models.Dto;

namespace Telemedicine_AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

       Task<String> Register(RegistrationRequestDto registrationRequestDto);

    }
}
