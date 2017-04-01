using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CourseLearning.Application.Interface;
using CourseLearning.Model;
using CourseLearning.Model.Courses;

namespace CourseLearning.WebAPI.Controllers.AdminControllers
{
    [RoutePrefix("api/admin/course")]
    public class AdminCourseController : ApiController
    {
        private readonly ICourseService _courseService;

        public AdminCourseController(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _courseService.Get(id));
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(Course course)
        {
            await _courseService.Add(course);

            return Ok();
        }


    }
}
