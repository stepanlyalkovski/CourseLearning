using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;

namespace CourseLearning.DAL
{
    public class ModuleRepository : BaseRepository<Module>, IModuleRepository
    {
        public ModuleRepository(DbContext context) : base(context)
        {
        }

        public async Task<IList<Module>> GetCourseModules(int courseId)
        {
            return await Context.Set<Module>().Where(m => m.Course.CourseId == courseId).ToListAsync();
        }

        public void AttachArticle(Article article, Module module)
        {
            var dbModule = Context.Set<Module>().Attach(module);
            dbModule.Articles = module.Articles ?? new List<Article>();
            dbModule.Articles.Add(article);
        }
    }
}