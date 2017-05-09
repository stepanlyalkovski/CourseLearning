using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CourseLearning.Application.Interface;

namespace CourseLearning.WebAPI.Controllers
{
    [Authorize]
    public class TestController : ApiController
    {
        private readonly ICourseService _courseService;

        private readonly IUserService _userService;

        public TestController(ICourseService courseService, IUserService userService)
        {
            _courseService = courseService;
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var user = HttpContext.Current.User;
            var result = await _userService.Get(user.Identity.Name);
            return Ok(User);
        }

        //[HttpGet]
        //public async Task<IHttpActionResult> Values(int id)
        //{
        //    string result = _courseService.Test().ToString();
        //    var course = new Course
        //    {
        //        Name = "awesome course Num " + id,
        //        Creator = new User {Name = "awesome User"},
        //        Description = "some awesome course"
        //    };

        //    await _courseService.Add(course);

        //    return Ok(new List<string> {"one", "two", "hey", "something else", result });
        //}
    }
}
