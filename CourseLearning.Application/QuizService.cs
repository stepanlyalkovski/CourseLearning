using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CourseLearning.Application.Interface;
using CourseLearning.Application.Mapper;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly DtoMapper<Quiz, QuizDTO> _quizMapper = new DtoMapper<Quiz, QuizDTO>();

        public QuizService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(QuizDTO quiz)
        {
            var quizEntity = _quizMapper.ToEntity(quiz);
            _unitOfWork.Quizzes.Add(quizEntity);
            await _unitOfWork.CompleteAsync();
            return quizEntity.QuizId;
        }

        public async Task<QuizDTO> Get(int id)
        {
            var quiz = await _unitOfWork.Quizzes.FindAsync(id);
            return _quizMapper.ToEntityDTO(quiz);
        }

        public Task Delete(QuizDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(QuizDTO quizDto)
        {
            var user = await _unitOfWork.Users.GetAsync(HttpContext.Current.User.Identity.Name);
            foreach (var question in quizDto.QuizQuestionList.Select(qq => qq.Question))
            {
                if (question.QuestionId == 0)
                {
                    question.CreatorId = user.UserId;
                }
            }
            var quiz = _quizMapper.ToEntity(quizDto);
            await _unitOfWork.Quizzes.Update(quiz);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IList<QuizDTO>> GetModuleQuizzes(int moduleId)
        {
            var quizzes = await _unitOfWork.Quizzes.GetModuleQuizzes(moduleId);
            return _quizMapper.ToEntitiesDTO(quizzes);
        }
    }
}