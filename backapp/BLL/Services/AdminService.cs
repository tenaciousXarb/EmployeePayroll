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
    public class AdminService
    {
        public static AdminDTO AddAdmin(AdminDTO emp)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<AdminDTO, Admin>();
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Admin>(emp);
            var rt = DataAccessFactory.AdminDataAccess().Add(data);
            if (rt != null)
            {
                return mapper.Map<AdminDTO>(rt);
            }
            return null;
        }
        public static List<AdminDTO> Get()
        {
            var data = DataAccessFactory.AdminDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<AdminDTO>>(data);
        }
        public static AdminDTO Get(int id)
        {
            var data = DataAccessFactory.AdminDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<AdminDTO>(data);
        }
        public static AdminDTO Edit(AdminDTO emp)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<AdminDTO, Admin>();
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Admin>(emp);
            var rt = DataAccessFactory.AdminDataAccess().Update(data);
            if (rt != null)
            {
                return mapper.Map<AdminDTO>(rt);
            }
            return null;
        }
        public static bool Delete(int id)
        {
            var data = DataAccessFactory.AdminDataAccess().Delete(id);
            if (data)
            {
                return true;
            }
            return false;
        }
    }
}
