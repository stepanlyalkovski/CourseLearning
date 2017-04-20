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
    [RoutePrefix("api/admin/module")]
    public class AdminModuleController : ApiController
    {
        private readonly IModuleService _moduleService;
        private readonly IArticleService _articleService;
        private readonly IQuizService _quizService;

        public AdminModuleController(IModuleService moduleService, IArticleService articleService, IQuizService quizService)
        {
            _moduleService = moduleService;
            _articleService = articleService;
            _quizService = quizService;
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _moduleService.Get(id));
        }

        [Route("{moduleId:int}/articles")]
        [HttpGet]
        public async Task<IHttpActionResult> GetModuleArticles(int moduleId)
        {
            return Ok(await _articleService.GetModuleArticlesAsync(moduleId));
        }

        [Route("{moduleId:int}/articles")]
        [HttpPost]
        public async Task<IHttpActionResult> AttachArticle(int moduleId, [FromBody] ArticleDTO article)
        {
            await _moduleService.AttachArticle(article, moduleId);
            return Ok();
        }

        [Route("{moduleId:int}/quizzes")]
        [HttpGet]
        public async Task<IHttpActionResult> GetModuleQuizzes(int moduleId)
        {
            return Ok(await _quizService.GetModuleQuizzes(moduleId));
        }

        [Route("{moduleId:int}/quizzes")]
        [HttpPost]
        public async Task<IHttpActionResult> AddQuiz(int moduleId, [FromBody] QuizDTO quiz)
        {
            quiz.ModuleId = moduleId; //TODO find a better solution to set module id
            int createdId = await _quizService.Add(quiz);
            var createdQuiz = new QuizDTO { QuizId = createdId };
            return Created(Request.RequestUri + $"/{createdId}", createdQuiz);
        }

    }
}
