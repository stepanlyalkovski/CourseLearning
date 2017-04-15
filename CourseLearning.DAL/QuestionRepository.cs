using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model.Questions;

namespace CourseLearning.DAL
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(DbContext context) : base(context)
        {
        }

        public async Task<IList<QuizQuestion>> GetQuizQuestions(int quizId)
        {
            return await Context.Set<QuizQuestion>()
                .Include(q => q.Question.QuestionControlType)
                .Include(q => q.Question.QuestionControlList)
                .Where(q => q.QuizId == quizId).ToListAsync();
        }

        public void AddQuizQuestion(QuizQuestion quizQuestion)
        {
            if (quizQuestion.Question == null)
            {
                throw new ArgumentNullException(nameof(quizQuestion.Question));
            }

            if (quizQuestion.QuizId == 0)
            {
                throw new ArgumentException("quiz id is not specified", nameof(quizQuestion.QuizId));
            }

            if (quizQuestion.Question.QuestionId == 0)
            {
                Context.Entry(quizQuestion.Question).State = EntityState.Added;
            }
            else
            {
                Context.Set<Question>().Attach(quizQuestion.Question);
            }

            Context.Set<QuizQuestion>().Add(quizQuestion);
        }

        public override async Task<Question> FindAsync(int questionId)
        {
            return await Context.Set<Question>().Include(q => q.QuestionControlList).FirstOrDefaultAsync(q => q.QuestionId == questionId);
        }
    }
}