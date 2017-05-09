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

        private readonly IUserService _userService;

        public AdminCourseController(ICourseService courseService, IModuleService moduleService, IUserService userService)
        {
            _courseService = courseService;
            _moduleService = moduleService;
            _userService = userService;
        }

        
        
        [Route("{id:int?}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int? id = null)
        {
            var user = await _userService.Get(User.Identity.Name);
            if (id == null)
            {
                return Ok(await _courseService.GetUserCreatedCoursesAsync(user.UserId));
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
            int createdId = await _moduleService.Add(module);
            var createdModule = new ModuleDTO { ModuleId = createdId };
            return Created(Request.RequestUri + $"/{createdId}", createdModule);
        }

        [Route("{id:int}/courseSessions")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseSessionDTO courseSessionDto)
        {
            int createdId = await _courseService.CreateCourseSession(courseSessionDto);
            var createdSession = new CourseSessionDTO { CourseSessionId = createdId, CourseId = courseSessionDto.CourseId };
            return Created(Request.RequestUri + $"/{createdId}", createdSession);
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseDTO course)
        {
            int createdId = await _courseService.Add(course);
            var createdCourse = new CourseDTO { CourseId = createdId };
            return Created(Request.RequestUri + $"/{createdId}", createdCourse);
        }
    }
}
