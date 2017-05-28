using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using CourseLearning.Application.Interface;

namespace CourseLearning.WebAPI.Controllers
{
    public class CourseSessionController : ApiController
    {
        private readonly ICourseService _courseService;

        private readonly IModuleService _moduleService;

        private readonly IUserService _userService;

        public CourseSessionController(ICourseService courseService, IModuleService moduleService, IUserService userService)
        {
            _courseService = courseService;
            _moduleService = moduleService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int? id = null)
        {
            var user = await _userService.Get(User.Identity.Name);
            if (id == null)
            {
                return Ok(await _courseService.GetActiveCourseSessions());
            }
            var sessions = await _courseService.GetActiveCourseSessions();
            return Ok(sessions?.FirstOrDefault(s => s.CourseSessionId == id.Value));
        }
    }
}
