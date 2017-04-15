using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model.Questions;

namespace CourseLearning.DAL.Interface
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<IList<QuizQuestion>> GetQuizQuestions(int quizId);

        void AddQuizQuestion(QuizQuestion quizQuestion);
    }
}