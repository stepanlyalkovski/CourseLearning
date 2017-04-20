using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application.Interface
{
    public interface IArticleService : IEntityService<ArticleDTO>
    {
        Task<IList<ArticleDTO>> GetModuleArticlesAsync(int moduleId);

        Task<IList<ArticleDTO>> GetCreatorArticlesAsync(int creatorId);
    }
}