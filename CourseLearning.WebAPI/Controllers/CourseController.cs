﻿using System;
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
    [Authorize]
    [RoutePrefix("api/client/course")]
    public class CourseController : ApiController
    {
        private readonly ICourseService _courseService;

        private readonly IModuleService _moduleService;

        private readonly IUserService _userService;

        public CourseController(ICourseService courseService, IModuleService moduleService, IUserService userService)
        {
            _courseService = courseService;
            _moduleService = moduleService;
            _userService = userService;
        }

        [Route("{id:int?}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int? id = null)
        {
            Thread.Sleep(1000);
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
    }
}
