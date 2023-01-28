using AutoMapper;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Services
{
    public class TokenService
    {
        public static TokenDTO AddToken(TokenDTO emp)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<TokenDTO, Token>();
                c.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Token>(emp);
            var rt = DataAccessFactory.TokenDataAccess().Add(data);
            if (rt != null)
            {
                return mapper.Map<TokenDTO>(rt);
            }
            return null;
        }
        public static List<TokenDTO> Get()
        {
            var data = DataAccessFactory.TokenDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<TokenDTO>>(data);
        }
        public static TokenDTO Get(string id)
        {
            var data = DataAccessFactory.TokenDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<TokenDTO>(data);
        }
        public static TokenDTO Edit(TokenDTO emp)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<TokenDTO, Token>();
                c.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Token>(emp);
            var rt = DataAccessFactory.TokenDataAccess().Update(data);
            if (rt != null)
            {
                return mapper.Map<TokenDTO>(rt);
            }
            return null;
        }
        public static bool Delete(string id)
        {
            var data = DataAccessFactory.TokenDataAccess().Delete(id);
            if (data)
            {
                return true;
            }
            return false;
        }
    }
}
