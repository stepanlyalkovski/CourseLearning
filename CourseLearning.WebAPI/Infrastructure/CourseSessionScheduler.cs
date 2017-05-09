using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseLearning.WebAPI.Jobs;
using Quartz;
using Quartz.Impl;

namespace CourseLearning.WebAPI.Infrastructure
{
    public class CourseSessionScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            int hourInterval = 24;

            scheduler.Start();

            IJobDetail job = JobBuilder.Create<CourseSessionJob>().Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("sessionTrigger", "SessionGroup")
                .StartNow()                           
                .WithSimpleSchedule(x => x            
                    .WithIntervalInHours(hourInterval)          
                    .RepeatForever())                  
                .Build();                              

            scheduler.ScheduleJob(job, trigger);      
        }
    }
}