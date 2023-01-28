using BLL.DTO;
using BLL.Services;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;

namespace EmployeePayroll.Scheduler
{
    public class Job: IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var emps = EmployeeService.Get();
            foreach(var e in emps)
            {
                var post = new TransactionDTO()
                {
                    EmpId = e.Id,
                    Amount = e.Salary,
                    Date = DateTime.Now,
                    Month = DateTime.Now.ToString("MMMM"),
                    AdminId = 1,
                };
                TransactionService.AddTransaction(post);
            }
        }
    }
}