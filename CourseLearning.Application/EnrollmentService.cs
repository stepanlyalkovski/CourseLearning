using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLearning.Application.Helpers;
using CourseLearning.Application.Interface;
using CourseLearning.Application.Mapper;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;
using CourseLearning.Model.Courses;
using CourseLearning.Model.DTO.Enrollments;
using CourseLearning.Model.Enrollments;
using CourseLearning.Model.Lessons;

namespace CourseLearning.Application
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly DtoMapper<EnrollmentSession, EnrollmentSessionDTO> _sessionMapper = new DtoMapper<EnrollmentSession, EnrollmentSessionDTO>();

        public EnrollmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<EnrollmentSessionDTO>> GetUserEnrollments()
        {
            var user = await UserHelper.GetCurrentUser(_unitOfWork);
            var session = await _unitOfWork.Enrollments.GetUserEnrollments(user.UserId);
            return _sessionMapper.ToEntitiesDTO(session);
        }

        public async Task<EnrollmentSessionDTO> GetCourseEnrollment(int courseSessionId)
        {
            var user = await UserHelper.GetCurrentUser(_unitOfWork);
            var session = await _unitOfWork.Enrollments.GetCourseEnrollment(user.UserId, courseSessionId);
            return _sessionMapper.ToEntityDTO(session);
        }

        public async Task<EnrollmentSessionDTO> CreateEnrollment(int courseSessionId)
        {
            var courseSession = (await _unitOfWork.Courses.GetCourseSessionsAsync()).FirstOrDefault(s => s.CourseSessionId == courseSessionId);
            var enrollment = new EnrollmentSession();
            var user = await UserHelper.GetCurrentUser(_unitOfWork);
            var course = await _unitOfWork.Courses.GetFullCourse(courseSession.CourseId);     
            enrollment.UserId = user.UserId;
            enrollment.CourseSessionId = courseSessionId;
            CreateModuleEnrollments(enrollment, course);

            _unitOfWork.Enrollments.Add(enrollment);
            await _unitOfWork.CompleteAsync();

            return _sessionMapper.ToEntityDTO(enrollment);
        }

        private void CreateModuleEnrollments(EnrollmentSession enrollment, Course course)
        {
            enrollment.EnrollmentSessionModules = new List<EnrollmentSessionModule>();

            foreach (var courseModule in course.Modules)
            {
                var enrollmentModule = new EnrollmentSessionModule
                {
                    ModuleId = courseModule.ModuleId,
                    IsEnabled = true
                };

                CreateArticleEnrollments(enrollmentModule, courseModule.Articles);
                CreateQuizEnrollments(enrollmentModule, courseModule.Quizzes);
                CreateLessonEnrollments(enrollmentModule, courseModule.Lessons);

                enrollment.EnrollmentSessionModules.Add(enrollmentModule);
            }
        }

        private void CreateArticleEnrollments(EnrollmentSessionModule sessionModule, IList<Article> articles)
        {
            sessionModule.EnrollmentSessionArticles = new List<EnrollmentSessionArticle>();

            foreach (var moduleArticle in articles)
            {
                var articleSession = new EnrollmentSessionArticle {ArticleId = moduleArticle.ArticleId};
                sessionModule.EnrollmentSessionArticles.Add(articleSession);
            }
        }

        private void CreateQuizEnrollments(EnrollmentSessionModule sessionModule, IList<Quiz> quizzes)
        {
            sessionModule.EnrollmentSessionQuizzes = new List<EnrollmentSessionQuiz>();

            foreach (var quiz in quizzes)
            {
                var enrollmentQuiz = new EnrollmentSessionQuiz {QuizId = quiz.QuizId};
                sessionModule.EnrollmentSessionQuizzes.Add(enrollmentQuiz);
            }
        }

        private void CreateLessonEnrollments(EnrollmentSessionModule sessionModule, IList<Lesson> lessons)
        {
            sessionModule.EnrollmentSessionLessons = new List<EnrollmentSessionLesson>();
            foreach (var lesson in lessons)
            {
                var lessonEnrollment = new EnrollmentSessionLesson {LessonId = lesson.LessonId};
                sessionModule.EnrollmentSessionLessons.Add(lessonEnrollment);
            }
        }
    }
}