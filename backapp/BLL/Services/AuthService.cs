using AutoMapper;
using BLL.DTO.MainDTO;
using DAL;
using DAL.EF;

namespace BLL.Services
{
    public class AuthService
    {
        public static async Task<TokenDTO?> AuthenticateAdmin(string uname, string pass)
        {
            var user = await DataAccessFactory.AdminAuthDataAccess().Authenticate(uname, pass);
            if (user != null)
            {
                var tk = new Token();
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
                }
            }
            return null;
        }
        public static async Task<TokenDTO?> AuthenticateEmployee(string uname, string pass)
        {
            var user = await DataAccessFactory.EmployeeAuthDataAccess().Authenticate(uname, pass);
            if (user != null)
            {
                var tk = new Token();
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
                }
            }
            return null;
        }
        public static async Task<int?> IsTokenValid(string token)
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
        }
        public static async Task<bool> Logout(string token)
        {
            return await DataAccessFactory.AdminAuthDataAccess().Logout(token);
        }
        public static async Task<bool> EmpLogout(string token)
        {
            return await DataAccessFactory.EmployeeAuthDataAccess().Logout(token);
        }
    }
}
