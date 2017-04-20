using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model;

namespace CourseLearning.DAL.Interface
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<IList<Article>> GetModuleArticlesAsync(int moduleId);

        Task<IList<Article>> GetCreatorArticlesAsync(int creatorId);
    }
}