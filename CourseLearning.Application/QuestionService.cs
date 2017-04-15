using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Application.Interface;
using CourseLearning.Application.Mapper;
using CourseLearning.DAL.Interface;
using CourseLearning.Model.DTO;
using CourseLearning.Model.Questions;

namespace CourseLearning.Application
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly DtoMapper<Question, QuestionDTO> _questionMapper = new DtoMapper<Question, QuestionDTO>();

        private readonly DtoMapper<QuizQuestion, QuizQuestionDTO> _quizQuestionMapper = new DtoMapper<QuizQuestion, QuizQuestionDTO>();


        public QuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(QuestionDTO question)
        {
            var questionEntity = _questionMapper.ToEntity(question);
            _unitOfWork.Questions.Add(questionEntity);
            await _unitOfWork.CompleteAsync();
            return questionEntity.QuestionId;
        }

        public async Task<QuestionDTO> Get(int id)
        {
            var question = await _unitOfWork.Questions.FindAsync(id);
            return _questionMapper.ToEntityDTO(question);
        }

        public Task Delete(QuestionDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(QuestionDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<QuizQuestionDTO>> GetQuizQuestions(int quizId)
        {
           var quizzes = await _unitOfWork.Questions.GetQuizQuestions(quizId);
           return _quizQuestionMapper.ToEntitiesDTO(quizzes);
        }

        public async Task<int> AddQuizQuestion(QuizQuestionDTO quizQuestion)
        {
            var quizQuestionEntity = _quizQuestionMapper.ToEntity(quizQuestion);
            _unitOfWork.Questions.AddQuizQuestion(quizQuestionEntity);
            await _unitOfWork.CompleteAsync();
            return quizQuestionEntity.QuizQuestionId;
        }
    }
}