using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model;

namespace CourseLearning.DAL.Interface
{
    public interface IQuizRepository : IRepository<Quiz>
    {
        Task<IList<Quiz>> GetModuleQuizzes(int moduleId);
    }
}