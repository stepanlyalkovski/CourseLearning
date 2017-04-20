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
    [RoutePrefix("api/admin/article")]
    public class AdminArticleController : ApiController
    {
        private readonly IArticleService _articleService;

        public AdminArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _articleService.Get(id));
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(ArticleDTO article)
        {
            int creatorId = 1; //TODO update when user will be created
            article.CreatorId = creatorId;
            int createdId = await _articleService.Add(article);
            return Created(Request.RequestUri + $"/{createdId}", new ArticleDTO { ArticleId = createdId });
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCreatedArticles()
        {
            int creatorId = 1; //TODO update when user will be created
            return Ok(await _articleService.GetCreatorArticlesAsync(creatorId));
        }
    }
}
