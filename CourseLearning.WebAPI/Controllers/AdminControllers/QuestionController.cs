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
    public class QuestionController : ApiController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
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
            int creatorId = 1; //TODO update when user will be created
            question.CreatorId = creatorId;
            int createdId = await _questionService.Add(question);
            var createdQuestion = new QuestionDTO {QuestionId = createdId};
            return Created(Request.RequestUri + $"/{createdId}", createdQuestion);
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCreatedQuestins()
        {
            int creatorId = 1; //TODO update when user will be created
            return Ok(await _questionService.GetCreatorQuestionsAsync(creatorId));
        }
    }
}
