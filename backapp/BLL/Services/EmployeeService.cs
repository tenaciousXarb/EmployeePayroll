using AutoMapper;
using BLL.DTO.FormDTO;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService
    {
        public static EmployeeDTO AddEmployee(EmployeeRegistrationDTO emp)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<EmployeeRegistrationDTO, Employee>();
                c.CreateMap<Employee, EmployeeRegistrationDTO>();
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Employee>(emp);
            var rt = DataAccessFactory.EmployeeDataAccess().Add(data);
            return mapper.Map<EmployeeDTO>(rt);
        }
        public static List<EmployeeDTO> Get()
        {
            var data = DataAccessFactory.EmployeeDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<EmployeeDTO>>(data);
        }
        public static EmployeeDTO GetByName(string name)
        {
            var data = DataAccessFactory.EmployeeGetDataAccess().GetByUsername(name);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<EmployeeDTO>(data);
        }
        public static EmployeeDTO Get(int id)
        {
            var data = DataAccessFactory.EmployeeDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<EmployeeDTO>(data);
        }
        public static EmployeeDTO Edit(EmployeeDTO emp)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<EmployeeDTO, Employee>();
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Employee>(emp);
            var rt = DataAccessFactory.EmployeeDataAccess().Update(data);
            if (rt != null)
            {
                return mapper.Map<EmployeeDTO>(rt);
            }
            return null;
        }
        public static bool Delete(int id)
        {
            var data = DataAccessFactory.EmployeeDataAccess().Delete(id);
            if(data)
            {
                return true;
            }
            return false;
        }
    }
}
