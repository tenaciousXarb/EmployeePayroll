using BLL.DTO.MainDTO;
using BLL.Services;
using Quartz;

namespace AppCoreAPI.Scheduler
{
    public class Job : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var emps = EmployeeService.Get();
            foreach (var e in emps)
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
