using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePayroll.Scheduler
{
    public class TransactionScheduler
    {
        public static void Run()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<Job>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("Run Infinitely every 2nd day of the month", "Monthly_Day_2")
                .StartNow()
                .WithSchedule(CronScheduleBuilder.MonthlyOnDayAndHourAndMinute(2, 1, 0))
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}