using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model;

namespace CourseLearning.DAL.Interface
{
    public interface IModuleRepository : IRepository<Module>
    {
        Task<IList<Module>> GetCourseModules(int courseId);

        void AttachArticle(Article article, Module module);
    }
}