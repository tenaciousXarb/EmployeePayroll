using AutoMapper;
using BLL.DTO.MainDTO;
using DAL;
using DAL.EF;

namespace BLL.Services
{
    public class TokenService
    {
        public static async Task<TokenDTO?> AddToken(TokenDTO obj)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<TokenDTO, Token>();
                c.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Token>(obj);
            var rt = await DataAccessFactory.TokenDataAccess().Add(data);
            if (rt != null)
            {
                return mapper.Map<TokenDTO>(rt);
            }
            return null;
        }
        public static async Task<List<TokenDTO>?> Get()
        {
            var data = await DataAccessFactory.TokenDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<TokenDTO>>(data);
        }
        public static async Task<TokenDTO?> Get(string id)
        {
            var data = await DataAccessFactory.TokenDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<TokenDTO>(data);
        }
        public static async Task<TokenDTO?> Edit(TokenDTO obj)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<TokenDTO, Token>();
                c.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Token>(obj);
            var rt = await DataAccessFactory.TokenDataAccess().Update(data);
            if (rt != null)
            {
                return mapper.Map<TokenDTO>(rt);
            }
            return null;
        }
        public static async Task<bool> Delete(string id)
        {
            var data = await DataAccessFactory.TokenDataAccess().Delete(id);
            if (data)
            {
                return true;
            }
            return false;
        }
    }
}
