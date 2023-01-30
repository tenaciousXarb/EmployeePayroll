using AutoMapper;
using BLL.DTO.MainDTO;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminService
    {
        public static async Task<AdminDTO?> AddAdmin(AdminDTO obj)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<AdminDTO, Admin>();
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Admin>(obj);
            var rt = await DataAccessFactory.AdminDataAccess().Add(data);
            return mapper.Map<AdminDTO>(rt);
        }
        public static async Task<List<AdminDTO>?> Get()
        {
            var data = await DataAccessFactory.AdminDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<AdminDTO>>(data);
        }
        public static async Task<AdminDTO?> Get(int id)
        {
            var data = await DataAccessFactory.AdminDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<AdminDTO>(data);
        }
        public static async Task<AdminDTO?> Edit(AdminDTO obj)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<AdminDTO, Admin>();
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Admin>(obj);
            var rt = await DataAccessFactory.AdminDataAccess().Update(data);
            return mapper.Map<AdminDTO>(rt);
        }
        public static async Task<bool> Delete(int id)
        {
            return await DataAccessFactory.AdminDataAccess().Delete(id);
        }
    }
}
