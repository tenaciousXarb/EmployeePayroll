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
    public class VacationService
    {
        public static VacationDTO AddVacation(VacationDTO emp)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<VacationDTO, Vacation>();
                c.CreateMap<Vacation, VacationDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Vacation>(emp);
            var rt = DataAccessFactory.VacationDataAccess().Add(data);

            return mapper.Map<VacationDTO>(rt);
        }
        public static List<VacationDTO> Get()
        {
            var data = DataAccessFactory.VacationDataAccess().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Vacation, VacationDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper.Map<List<VacationDTO>>(data);
        }
        public static VacationDTO Get(int id)
        {
            var data = DataAccessFactory.VacationDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Vacation, VacationDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper.Map<VacationDTO>(data);
        }
        public static VacationDTO Edit(VacationDTO emp, int value)
        {
            var e = EmployeeService.Get((int)emp.EmpId);
            if (e.RemLeave >= emp.Nod)
            {
                e.RemLeave = e.RemLeave - emp.Nod;
                var ein = EmployeeService.Edit(e);
            }
            else
            {
                int diff = 0;
                if (e.RemLeave > 0)
                {
                    diff = (int)(emp.Nod - e.RemLeave);
                }
                else
                {
                    diff = (int)emp.Nod;
                }
                e.RemLeave = e.RemLeave - emp.Nod;
                var ein = EmployeeService.Edit(e);
                var post = new TransactionDTO()
                {
                    EmpId = e.Id,
                    Amount = (-100 * diff),
                    Date = DateTime.Now,
                    Month = DateTime.Now.ToString("MMMM"),
                    AdminId = 1
                };
                TransactionService.AddTransaction(post);
            }
            if (value == 1)
            {
                emp.Status = "Approved";
            }
            else
            {
                emp.Status = "Rejected";
            }
            emp.AdminId = 1;

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<VacationDTO, Vacation>();
                c.CreateMap<Vacation, VacationDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Vacation>(emp);
            var rt = DataAccessFactory.VacationDataAccess().Update(data);

            return mapper.Map<VacationDTO>(rt);
        }
        public static bool Delete(int id)
        {
            var data = DataAccessFactory.VacationDataAccess().Delete(id);
            return data;
        }
    }
}
