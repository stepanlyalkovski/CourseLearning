using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CourseLearning.Application.Interface;
using CourseLearning.Model.DTO;

namespace CourseLearning.WebAPI.Controllers.AdminControllers
{
    [RoutePrefix("api/admin/course")]
    public class AdminCourseController : ApiController
    {
        private readonly ICourseService _courseService;
        private readonly IModuleService _moduleService;

        public AdminCourseController(ICourseService courseService, IModuleService moduleService)
        {
            _courseService = courseService;
            _moduleService = moduleService;
        }

        
        [Route("{id:int?}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int? id = null)
        {
            int userIdStub = 1;
            if (id == null)
            {
                return Ok(await _courseService.GetUserCreatedCoursesAsync(userIdStub));
            }

            return Ok(await _courseService.Get(id.Value));
        }

        [Route("{id:int}/modules")]
        [HttpGet]
        public async Task<IHttpActionResult> GetModules(int id)
        {
            return Ok(await _moduleService.GetCourseModules(id));
        }

        [Route("{id:int}/modules")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(ModuleDTO module)
        {
            return Ok(await _moduleService.Add(module));
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseDTO course)
        {            
            return Ok(await _courseService.Add(course));
        }
    }
}
