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

        public AuthService() { }

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string?> AuthenticateAdmin(string uname, string pass)
        {
            var user = await DataAccessFactory.AdminAuthDataAccess().Authenticate(uname, pass);
            if (user != null)
            {
                /*var tk = new Token();
                tk.Username = user.Username;
                tk.CreationTime = DateTime.Now;
                tk.ExpirationTime = null;
                tk.Tkey = Guid.NewGuid().ToString();
                tk.Post = "Admin";
                var rttk = await DataAccessFactory.TokenDataAccess().Add(tk);
                if (rttk != null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var data = mapper.Map<TokenDTO>(rttk);
                    return data;
                }*/

                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("user_id", user.Id.ToString()),
                    new Claim("user", user.Username),
                    new Claim("role", "admin")
                };

                //var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt")["Key"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                /*var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);*/

                var issuer = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt")["Issuer"];
                var audience = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt")["Audience"];
                var token = new JwtSecurityToken(
                    issuer,
                    audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
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
                /*var tk = new Token();
                tk.Username = user.Username;
                tk.CreationTime = DateTime.Now;
                tk.ExpirationTime = null;
                tk.Tkey = Guid.NewGuid().ToString();
                tk.Post = "Employee";
                var rttk = await DataAccessFactory.TokenDataAccess().Add(tk);
                if (rttk != null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var data = mapper.Map<TokenDTO>(rttk);
                    return data;
                }*/


                var claims = new List<Claim>
                {
                    new Claim("user_id", user.Id.ToString()),
                    new Claim("user", user.Username),
                    new Claim("role", "employee")
                };

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
                var securityKey = new SymmetricSecurityKey(
                 Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                var tk = new JwtSecurityTokenHandler().WriteToken(token);
                return tk;
            }
            return null;
        }
        /*public static async Task<int?> IsTokenValid(string token)
        {
            var tk = await DataAccessFactory.TokenDataAccess().Get(token);
            if (tk == null)
            {
                return 0;
            }
            else if (tk.ExpirationTime != null)
            {
                return 1;
            }
            return 2;
        }*/
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
