using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;

namespace CourseLearning.DAL
{
    public class QuizRepository : BaseRepository<Quiz>, IQuizRepository
    {
        public QuizRepository(DbContext context) : base(context)
        {
        }

        public async Task<IList<Quiz>> GetModuleQuizzes(int moduleId)
        {
            return await Context.Set<Quiz>().Where(q => q.Module.ModuleId == moduleId).ToListAsync();
        }
    }
}