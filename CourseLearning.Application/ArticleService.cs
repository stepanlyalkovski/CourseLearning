using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Application.Interface;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application
{
    public class ArticleService : BaseEntityService<Article, ArticleDTO>, IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(ArticleDTO articleDTO)
        {
            var article = ToEntity(articleDTO);

            //current user check

            _unitOfWork.Articles.Add(article);
            await _unitOfWork.CompleteAsync();
            return article.ArticleId;
        }

        public async Task<ArticleDTO> Get(int id)
        {
            var article = await _unitOfWork.Articles.FindAsync(id);
            return ToEntityDTO(article);
        }

        public Task Delete(ArticleDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(ArticleDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<ArticleDTO>> GetModuleArticlesAsync(int moduleId)
        {
            var moduleArticles = await _unitOfWork.Articles.GetModuleArticlesAsync(moduleId);
            return ToEntitiesDTO(moduleArticles);
        }

        public async Task<IList<ArticleDTO>> GetCreatorArticlesAsync(int creatorId)
        {
            var articles = await _unitOfWork.Articles.GetCreatorArticlesAsync(creatorId);
            return ToEntitiesDTO(articles);
        }
    }
}