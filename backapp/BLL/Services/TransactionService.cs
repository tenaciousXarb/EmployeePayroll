using AutoMapper;
using BLL.DTO.MainDTO;
using DAL;
using DAL.EF;

namespace BLL.Services
{
    public class TransactionService
    {
        public static TransactionDTO AddTransaction(TransactionDTO emp)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<TransactionDTO, Transaction>();
                c.CreateMap<Transaction, TransactionDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Transaction>(emp);
            var rt = DataAccessFactory.TransactionDataAccess().Add(data);
            if (rt != null)
            {
                return mapper.Map<TransactionDTO>(rt);
            }
            return null;
        }
        public static List<TransactionDTO> Get()
        {
            var data = DataAccessFactory.TransactionDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Transaction, TransactionDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<TransactionDTO>>(data);
        }
        public static List<TransactionDTO> Get(int id)
        {
            var data = DataAccessFactory.TransactionGetSelectedDataAccess().GetSelected(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Transaction, TransactionDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<TransactionDTO>>(data);
        }
        public static TransactionDTO Edit(TransactionDTO emp)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<TransactionDTO, Transaction>();
                c.CreateMap<Transaction, TransactionDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Transaction>(emp);
            var rt = DataAccessFactory.TransactionDataAccess().Update(data);
            if (rt != null)
            {
                return mapper.Map<TransactionDTO>(rt);
            }
            return null;
        }
        public static bool Delete(int id)
        {
            var data = DataAccessFactory.TransactionDataAccess().Delete(id);
            if (data)
            {
                return true;
            }
            return false;
        }
    }
}
