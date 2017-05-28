using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using CourseLearning.Application.Interface;
using CourseLearning.Model.DTO.Enrollments;

namespace CourseLearning.WebAPI.Controllers
{
    [Authorize]
    public class EnrollmentController : ApiController
    {
        private IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetUserEnrollments()
        {
            return Ok(await _enrollmentService.GetUserEnrollments());
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetUserEnrollment(int courseSessionId)
        {
            var enr = await _enrollmentService.GetCourseEnrollment(courseSessionId);
            return Ok(enr);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostEnrollment(EnrollmentSessionDTO enrollmentSession)
        {
            var enr = await _enrollmentService.CreateEnrollment(enrollmentSession.CourseSessionId);
            return Ok(enr);
        }
    }
}
