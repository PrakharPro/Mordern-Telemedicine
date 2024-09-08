using Telemedicine_AuthAPI.Models;

namespace Telemedicine_AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user);
    }
}
