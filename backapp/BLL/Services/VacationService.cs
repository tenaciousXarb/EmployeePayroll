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
        public static async Task<VacationDTO?> AddVacation(VacationDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<VacationDTO, Vacation>();
                c.CreateMap<Vacation, VacationDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Vacation>(obj);
            var rt = await DataAccessFactory.VacationDataAccess().Add(data);

            return mapper.Map<VacationDTO>(rt);
        }
        public static async Task<List<VacationDTO>?> Get()
        {
            var data = await DataAccessFactory.VacationDataAccess().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Vacation, VacationDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper.Map<List<VacationDTO>>(data);
        }
        public static async Task<VacationDTO?> Get(int id)
        {
            var data = await DataAccessFactory.VacationDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Vacation, VacationDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper.Map<VacationDTO>(data);
        }
        public static async Task<VacationDTO?> Edit(VacationDTO obj, int value)
        {
            if(obj.EmpId != null && obj.Nod != null)
            {
                var e = await EmployeeService.Get((int)obj.EmpId) ?? throw new ArgumentNullException(nameof(EmployeeDTO));
                if (e.RemLeave >= obj.Nod)
                {
                    e.RemLeave = e.RemLeave - obj.Nod;
                    var ein = await EmployeeService.Edit(e);
                }
                else
                {
                    int diff = 0;
                    if (e.RemLeave > 0)
                    {
                        diff = (int)(obj.Nod - e.RemLeave);
                    }
                    else
                    {
                        diff = (int)obj.Nod;
                    }
                    e.RemLeave = e.RemLeave - obj.Nod;
                    var ein = await EmployeeService.Edit(e);
                    var post = new TransactionDTO()
                    {
                        EmpId = e.Id,
                        Amount = (-100 * diff),
                        Date = DateTime.Now,
                        Month = DateTime.Now.ToString("MMMM"),
                        AdminId = 1
                    };
                    await TransactionService.AddTransaction(post);
                }
            }
            if (value == 1)
            {
                obj.Status = "Approved";
            }
            else
            {
                obj.Status = "Rejected";
            }
            obj.AdminId = 1;

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<VacationDTO, Vacation>();
                c.CreateMap<Vacation, VacationDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Vacation>(obj);
            var rt = await DataAccessFactory.VacationDataAccess().Update(data);

            return mapper.Map<VacationDTO>(rt);
        }
        public static async Task<bool> Delete(int id)
        {
            return await DataAccessFactory.VacationDataAccess().Delete(id);
        }
    }
}
