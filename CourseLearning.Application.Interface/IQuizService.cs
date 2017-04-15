using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application.Interface
{
    public interface IQuizService : IEntityService<QuizDTO>
    {
        Task<IList<QuizDTO>> GetModuleQuizzes(int moduleId);

    }
}