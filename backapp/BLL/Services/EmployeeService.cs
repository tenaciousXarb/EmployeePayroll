using AutoMapper;
using BLL.DTO.FormDTO;
using BLL.DTO.MainDTO;
using DAL;
using DAL.EF;

namespace BLL.Services
{
    public class EmployeeService
    {
        public static async Task<EmployeeDTO?> AddEmployee(EmployeeRegistrationDTO obj)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<EmployeeRegistrationDTO, Employee>();
                c.CreateMap<Employee, EmployeeRegistrationDTO>();
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Employee>(obj);
            var rt = await DataAccessFactory.EmployeeDataAccess().Add(data);
            return mapper.Map<EmployeeDTO>(rt);
        }
        public static async Task<List<EmployeeDTO>?> Get()
        {
            var data = await DataAccessFactory.EmployeeDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<EmployeeDTO>>(data);
        }
        public static async Task<EmployeeDTO?> GetByName(string name)
        {
            var data = await DataAccessFactory.EmployeeGetDataAccess().GetByUsername(name);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<EmployeeDTO>(data);
        }
        public static async Task<EmployeeDTO?> Get(int id)
        {
            var data = await DataAccessFactory.EmployeeDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<EmployeeDTO>(data);
        }
        public static async Task<EmployeeDTO?> Edit(EmployeeDTO obj)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<EmployeeDTO, Employee>();
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Employee>(obj);
            var rt = await DataAccessFactory.EmployeeDataAccess().Update(data);
            if (rt != null)
            {
                return mapper.Map<EmployeeDTO>(rt);
            }
            return null;
        }
        public static async Task<bool> Delete(int id)
        {
            var data = await DataAccessFactory.EmployeeDataAccess().Delete(id);
            if (data)
            {
                return true;
            }
            return false;
        }
    }
}
