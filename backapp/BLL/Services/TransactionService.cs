using AutoMapper;
using BLL.DTO.MainDTO;
using DAL;
using DAL.EF;

namespace BLL.Services
{
    public class TransactionService
    {
        public static async Task<TransactionDTO?> AddTransaction(TransactionDTO obj)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<TransactionDTO, Transaction>();
                c.CreateMap<Transaction, TransactionDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Transaction>(obj);
            var rt = await DataAccessFactory.TransactionDataAccess().Add(data);
            if (rt != null)
            {
                return mapper.Map<TransactionDTO>(rt);
            }
            return null;
        }
        public static async Task<List<TransactionDTO>?> Get()
        {
            var data = await DataAccessFactory.TransactionDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Transaction, TransactionDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<TransactionDTO>>(data);
        }
        public static async Task<List<TransactionDTO>?> Get(int id)
        {
            var data = await DataAccessFactory.TransactionGetSelectedDataAccess().GetSelected(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Transaction, TransactionDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<TransactionDTO>>(data);
        }
        public static async Task<TransactionDTO?> Edit(TransactionDTO obj)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<TransactionDTO, Transaction>();
                c.CreateMap<Transaction, TransactionDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Transaction>(obj);
            var rt = await DataAccessFactory.TransactionDataAccess().Update(data);
            if (rt != null)
            {
                return mapper.Map<TransactionDTO>(rt);
            }
            return null;
        }
        public static async Task<bool> Delete(int id)
        {
            return await DataAccessFactory.TransactionDataAccess().Delete(id);
        }
    }
}
