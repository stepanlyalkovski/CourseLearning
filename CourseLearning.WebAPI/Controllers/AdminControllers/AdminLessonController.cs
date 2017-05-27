using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CourseLearning.Application.Interface;
using CourseLearning.Model.DTO.Lessons;

namespace CourseLearning.WebAPI.Controllers.AdminControllers
{
    [RoutePrefix("api/admin/lesson")]
    public class AdminLessonController : ApiController
    {
        private readonly ILessonService _lessonService;

        public AdminLessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        
        [Route("{lessonId:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int lessonId)
        {
            return Ok(await _lessonService.Get(lessonId));
        }

        [Route("{lessonId:int}/pages")]
        [HttpPost]
        public async Task<IHttpActionResult> AddPagePost(LessonPageDTO lessonPage)
        {
            var createdPage = await _lessonService.AddLessonPage(lessonPage);
            return Created(Request.RequestUri + $"/{createdPage.LessonPageId}", createdPage);
        }

        [Route("{lessonId:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateLesson(LessonDTO lesson)
        {
            await _lessonService.Update(lesson);
            return Ok();
        }
    }
}
