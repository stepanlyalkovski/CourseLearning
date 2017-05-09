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
    [RoutePrefix("api/admin/question")]
    public class AdminQuestionController : ApiController
    {
        private readonly IQuestionService _questionService;

        private readonly IUserService _userService;

        public AdminQuestionController(IQuestionService questionService, IUserService userService)
        {
            _questionService = questionService;
            _userService = userService;
        }

        public AdminQuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        
        [Route("{id:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _questionService.Get(id));
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(QuestionDTO question)
        {
            var user = await _userService.Get(User.Identity.Name);
            question.CreatorId = user.UserId;
            int createdId = await _questionService.Add(question);
            var createdQuestion = new QuestionDTO {QuestionId = createdId};
            return Created(Request.RequestUri + $"/{createdId}", createdQuestion);
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCreatedQuestins()
        {
            var user = await _userService.Get(User.Identity.Name);
            return Ok(await _questionService.GetCreatorQuestionsAsync(user.UserId));
        }
    }
}
