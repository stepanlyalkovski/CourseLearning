using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model.DTO;
using CourseLearning.Model.Questions;

namespace CourseLearning.Application.Interface
{
    public interface IQuestionService : IEntityService<QuestionDTO>
    {
        Task<IList<QuizQuestionDTO>> GetQuizQuestionsAsync(int quizId);

        Task<IList<QuestionDTO>> GetCreatorQuestionsAsync(int creatorId);

        Task<int> AddQuizQuestion(QuizQuestionDTO quizQuestion);
    }
}