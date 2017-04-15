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
            return Ok(await _questionService.Add(question));
        }
    }
}
