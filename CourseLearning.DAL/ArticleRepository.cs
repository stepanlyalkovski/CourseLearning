using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;

namespace CourseLearning.DAL
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(DbContext context) : base(context)
        {
        }

        public async Task<IList<Article>> GetModuleArticlesAsync(int moduleId)
        {
            return await Context.Set<Article>().Where(a => a.Modules.Any(m => m.ModuleId == moduleId)).ToListAsync();
        }

        public async Task<IList<Article>> GetCreatorArticlesAsync(int creatorId)
        {
            return await Context.Set<Article>().Where(a => a.CreatorId == creatorId).ToListAsync();
        }
    }
}