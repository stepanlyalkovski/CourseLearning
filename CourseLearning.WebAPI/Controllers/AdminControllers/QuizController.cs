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
    [RoutePrefix("api/admin/quiz")]
    public class QuizController : ApiController
    {
        private readonly IQuizService _quizService;

        private readonly IQuestionService _questionService;

        public QuizController(IQuizService quizService, IQuestionService questionService)
        {
            _quizService = quizService;
            _questionService = questionService;
        }
      
        [Route("{id:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _quizService.Get(id));
        }

        [Route("{quizId:int}/questions")]
        [HttpGet]
        public async Task<IHttpActionResult> GetQuizQuestions(int quizId)
        {
            return Ok(await _questionService.GetQuizQuestionsAsync(quizId));
        }

        [Route("{quizId:int}/questions")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(int quizId,[FromBody] int questionId)
        {
            return Ok(await _questionService.GetQuizQuestionsAsync(quizId));
        }

        [Route("{quizId:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutQuiz(int quizId, QuizDTO quiz)
        {
            await _quizService.Update(quiz);
            return Ok();
        }

    }
}
