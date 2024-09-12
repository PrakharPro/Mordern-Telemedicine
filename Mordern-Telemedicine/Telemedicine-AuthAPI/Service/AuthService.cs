using Mango.Services.AuthAPI.Data;
using Microsoft.AspNetCore.Identity;
using Telemedicine_AuthAPI.Models;
using Telemedicine_AuthAPI.Models.Dto;
using Telemedicine_AuthAPI.Service.IService;

namespace Telemedicine_AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDBContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
       public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(x => x.Name == loginRequestDto.UserName);
            var isValid = await _userManager.CheckPasswordAsync(user,loginRequestDto.Password);

            if(user == null || isValid == false)
            {
                return new LoginResponseDto() { 
                User=null,
                Token=""
                };
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            UserDto userDto = new()
            {
                Email=user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            

            return new LoginResponseDto() {
            User = userDto,
            Token= token
            };

        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser applicationUser = new()
            {
                UserName = registrationRequestDto.Name,
                Name = registrationRequestDto.Name,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                PhoneNumber = registrationRequestDto.PhoneNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser,registrationRequestDto.Password);

                if (result.Succeeded)
                {
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }catch(Exception ex){

            }
            return "Error Encountered";
        }

        public async Task<bool> AssignRole(string email, string rolename)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(rolename).GetAwaiter().GetResult())
                {
                    //create role if it doesn't exist
                    _roleManager.CreateAsync(new IdentityRole(rolename)).GetAwaiter().GetResult();
                }

                await _userManager.AddToRoleAsync(user,rolename);
                return true;
            }

            return false;

        }


    }
}
