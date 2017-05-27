using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CourseLearning.Application.Interface;
using CourseLearning.Model.DTO;

namespace CourseLearning.WebAPI.Controllers.AdminControllers
{
    [RoutePrefix("api/admin/article")]
    public class AdminArticleController : ApiController
    {
        private readonly IArticleService _articleService;

        private readonly IUserService _userService;

        public AdminArticleController(IArticleService articleService, IUserService userService)
        {
            _articleService = articleService;
            _userService = userService;
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
            var user = await _userService.Get(User.Identity.Name);
            article.CreatorId = user.UserId;
            int createdId = await _articleService.Add(article);
            return Created(Request.RequestUri + $"/{createdId}", new ArticleDTO { ArticleId = createdId });
        }

        [Route("")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateArticle(ArticleDTO article)
        {
            await _articleService.Update(article);
            return Ok();
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCreatedArticles()
        {
            var user = await _userService.Get(User.Identity.Name);
            return Ok(await _articleService.GetCreatorArticlesAsync(user.UserId));
        }
    }
}
