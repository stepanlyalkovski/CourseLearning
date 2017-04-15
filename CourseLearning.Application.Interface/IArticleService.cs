using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application.Interface
{
    public interface IArticleService : IEntityService<StorageArticleDTO>
    {
        Task<IList<StorageArticleDTO>> GetModuleArticlesAsync(int moduleId);
    }
}