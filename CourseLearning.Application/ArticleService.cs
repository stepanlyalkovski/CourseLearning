using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Application.Interface;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application
{
    public class ArticleService : BaseEntityService<Article, StorageArticleDTO>, IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(StorageArticleDTO articleDTO)
        {
            var article = ToEntity(articleDTO);

            var storageFolder = await _unitOfWork.StorageFolders.FindAsync(article.StorageFolderId);
            //current user check
            if (storageFolder == null)
            {
                throw new ArgumentException("storage folder with current id doesn't exist", nameof(articleDTO.StorageFolderId));
            }

            _unitOfWork.Articles.Add(article);
            await _unitOfWork.CompleteAsync();
            return article.ArticleId;
        }

        public async Task<StorageArticleDTO> Get(int id)
        {
            var article = await _unitOfWork.Articles.FindAsync(id);
            return ToEntityDTO(article);
        }

        public Task Delete(StorageArticleDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(StorageArticleDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<StorageArticleDTO>> GetModuleArticlesAsync(int moduleId)
        {
            var moduleArticles = await _unitOfWork.Articles.GetModuleArticlesAsync(moduleId);
            return ToEntitiesDTO(moduleArticles);
        }
    }
}