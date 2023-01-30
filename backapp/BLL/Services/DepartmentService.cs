using AutoMapper;
using BLL.DTO.MainDTO;
using DAL;
using DAL.EF;

namespace BLL.Services
{
    public class DepartmentService
    {
        public static async Task<DepartmentDTO?> AddDepartment(DepartmentDTO obj)
        {
            var cfg = new MapperConfiguration
            (c =>
            {
                c.CreateMap<DepartmentDTO, Department>().ReverseMap();
            }
            );
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Department>(obj);
            var rt = await DataAccessFactory.DepartmentDataAccess().Add(data);
            if (rt != null)
            {
                return mapper.Map<DepartmentDTO>(rt);
            }
            return null;
        }
        public static async Task<List<DepartmentDTO>?> Get()
        {
            var data = await DataAccessFactory.DepartmentDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Department, DepartmentDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<DepartmentDTO>>(data);
        }
        public static async Task<DepartmentDTO?> Get(int id)
        {
            var data = await DataAccessFactory.DepartmentDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Department, DepartmentDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<DepartmentDTO>(data);
        }
        public static async Task<DepartmentDTO?> Edit(DepartmentDTO obj)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<DepartmentDTO, Department>().ReverseMap();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Department>(obj);
            var rt = await DataAccessFactory.DepartmentDataAccess().Update(data);
            if (rt != null)
            {
                return mapper.Map<DepartmentDTO>(rt);
            }
            return null;
        }
        public static async Task<bool> Delete(int id)
        {
            var data = await DataAccessFactory.DepartmentDataAccess().Delete(id);
            if (data)
            {
                return true;
            }
            return false;
        }
    }
}
