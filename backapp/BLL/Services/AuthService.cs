using AutoMapper;
using BLL.DTO.MainDTO;
using DAL;
using DAL.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt");
        }

        /*public AuthService(IConfiguration configuration)
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt");
        }*/

        public async Task<string?> AuthenticateAdmin(string uname, string pass)
        {
            var user = await DataAccessFactory.AdminAuthDataAccess().Authenticate(uname, pass);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, user.Id.ToString()),
                    new Claim("user", user.Username),
                    new Claim("role", "admin")
                };

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Key"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuration["Issuer"],
                    _configuration["Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(90),
                    signingCredentials: creds);

                var tk = new JwtSecurityTokenHandler().WriteToken(token);
                return tk;
            }
            return null;
        }
        public async Task<string?> AuthenticateEmployee(string uname, string pass)
        {
            var user = await DataAccessFactory.EmployeeAuthDataAccess().Authenticate(uname, pass);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("user_id", user.Id.ToString()),
                    new Claim("user", user.Username),
                    new Claim("role", "employee")
                };

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Key"]));
                var securityKey = new SymmetricSecurityKey(
                 Encoding.ASCII.GetBytes(_configuration["Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuration["Issuer"],
                    _configuration["Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(90),
                    signingCredentials: creds);

                var tk = new JwtSecurityTokenHandler().WriteToken(token);
                return tk;
            }
            return null;
        }
        public static async Task<bool> Logout(string token)
        {
            return true;
        }
        public static async Task<bool> EmpLogout(string token)
        {
            return true;
        }
    }
}
