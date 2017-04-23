using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;
using CourseLearning.Model.Questions;

namespace CourseLearning.DAL
{
    public class QuizRepository : BaseRepository<Quiz>, IQuizRepository
    {
        private IQuestionRepository _questionRepository;

        public QuizRepository(DbContext context, IQuestionRepository questionRepository) : base(context)
        {
            _questionRepository = questionRepository;
        }

        public async Task<IList<Quiz>> GetModuleQuizzes(int moduleId)
        {
            return await Context.Set<Quiz>().Where(q => q.Module.ModuleId == moduleId).ToListAsync();
        }

        public override async Task<Quiz> FindAsync(int id)
        {
            return await Context.Set<Quiz>()
                                .Include(q => q.QuizQuestionList.Select(qq => qq.Question.ControlList))
                                .FirstOrDefaultAsync(q => q.QuizId == id);
        }

        public override async Task Update(Quiz quiz)
        {
            var attachedQuiz = await Context.Set<Quiz>().FindAsync(quiz.QuizId);
            AttachNewQuestions(quiz);

            var quizEntry = Context.Entry(attachedQuiz);
            quizEntry.CurrentValues.SetValues(quiz);

            var questionList = quizEntry.Collection(q => q.QuizQuestionList);
            await questionList.LoadAsync();

            foreach (var dbQuizQuestion in questionList.CurrentValue.ToList())
            {
                if (quiz.QuizQuestionList.All(q => q.QuizQuestionId != dbQuizQuestion.QuizQuestionId))
                {
                    Context.Set<QuizQuestion>().Remove(dbQuizQuestion);
                }
            }

            foreach (var quizQuestion in quiz.QuizQuestionList)
            {
                var dbQuizQuestion = questionList.CurrentValue.SingleOrDefault(q => q.QuizQuestionId == quizQuestion.QuizQuestionId);

                if (dbQuizQuestion != null)
                {
                    Context.Entry(dbQuizQuestion).CurrentValues.SetValues(quizQuestion);
                }
                else
                {
                    questionList.CurrentValue.Add(quizQuestion);
                }
            }
        }

        private void AttachNewQuestions(Quiz quiz)
        {
            foreach (var newQuestion in quiz.QuizQuestionList.Where(q => q.QuestionId == 0))
            {
                _questionRepository.Add(newQuestion.Question);
            }
        }

        //private void UpdateQuizQuestion(QuizQuestion quizQuestion)
        //{
        //    var attachedQuizQuestion = Context.Set<QuizQuestion>().Local.FirstOrDefault(q => q.QuizQuestionId == quizQuestion.QuizQuestionId);
        //    DbEntityEntry<QuizQuestion> quizQuestionEntry;
        //    if (attachedQuizQuestion != null)
        //    {
        //        quizQuestionEntry = Context.Entry(quizQuestion);
        //        quizQuestionEntry.CurrentValues.SetValues(quizQuestion);
        //    }
        //    else
        //    {
        //        quizQuestionEntry = Context.Entry(quizQuestion);
        //        quizQuestionEntry.State = EntityState.Modified;
        //    }

        //    if (quizQuestion.Question.QuestionId != 0)
        //    {
        //        return;
        //    }

        //    quizQuestionEntry.Property(q => q.Question).CurrentValue = quizQuestion.Question;
        //    //var attachedQuestion = Context.Set<Question>().Local.FirstOrDefault(q => q.QuizQuestionId == quizQuestion.QuizQuestionId);
        //    //DbEntityEntry<QuizQuestion> quizQuestionEntry;
        //    //if (attachedQuizQuestion != null)
        //    //{
        //    //    quizQuestionEntry = Context.Entry(quizQuestion);
        //    //    quizQuestionEntry.CurrentValues.SetValues(quizQuestion);
        //    //}
        //    //else
        //    //{
        //    //    quizQuestionEntry = Context.Entry(quizQuestion);
        //    //    quizQuestionEntry.State = EntityState.Modified;
        //    //}
        //}
    }
}