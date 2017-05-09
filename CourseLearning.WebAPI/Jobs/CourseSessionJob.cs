using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseLearning.Application.Interface;
using Quartz;

namespace CourseLearning.WebAPI.Jobs
{
    public class CourseSessionJob : IJob
    {
        private ICourseService _courseService;

        public CourseSessionJob(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void Execute(IJobExecutionContext context)
        {
            _courseService.UpdateActiveCourseSessions();
        }
    }
}