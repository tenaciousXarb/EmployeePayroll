using BLL.DTO.MainDTO;
using BLL.Services;
using Quartz;

namespace AppCoreAPI.Scheduler
{
    public class Job : IJob
    {
        public async void Execute(IJobExecutionContext context)
        {
            var emps = await EmployeeService.Get();
            if(emps != null)
            {
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
                    await TransactionService.AddTransaction(post);
                }
            }
        }
    }
}
