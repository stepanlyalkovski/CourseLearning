using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application.Interface
{
    public interface IModuleService : IEntityService<ModuleDTO>
    {
        Task<IList<ModuleDTO>> GetCourseModules(int courseId);

        Task AttachArticle(ArticleDTO article, int moduleId);
    }
}