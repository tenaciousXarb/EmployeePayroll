using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DepartmentService
    {
        public static DepartmentDTO AddDepartment(DepartmentDTO emp)
        {
            var cfg = new MapperConfiguration
            (c =>
                {
                    c.CreateMap<DepartmentDTO, Department>().ReverseMap();
                }
            );
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Department>(emp);
            var rt = DataAccessFactory.DepartmentDataAccess().Add(data);
            if (rt != null)
            {
                return mapper.Map<DepartmentDTO>(rt);
            }
            return null;
        }
        public static List<DepartmentDTO> Get()
        {
            var data = DataAccessFactory.DepartmentDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Department, DepartmentDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<DepartmentDTO>>(data);
        }
        public static DepartmentDTO Get(int id)
        {
            var data = DataAccessFactory.DepartmentDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Department, DepartmentDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<DepartmentDTO>(data);
        }
        public static DepartmentDTO Edit(DepartmentDTO emp)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<DepartmentDTO, Department>().ReverseMap();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Department>(emp);
            var rt = DataAccessFactory.DepartmentDataAccess().Update(data);
            if (rt != null)
            {
                return mapper.Map<DepartmentDTO>(rt);
            }
            return null;
        }
        public static bool Delete(int id)
        {
            var data = DataAccessFactory.DepartmentDataAccess().Delete(id);
            if (data)
            {
                return true;
            }
            return false;
        }
    }
}
