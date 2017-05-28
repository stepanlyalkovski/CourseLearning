using AutoMapper;
using CourseLearning.Model;
using CourseLearning.Model.ContentStorage;
using CourseLearning.Model.Courses;
using CourseLearning.Model.DTO;
using CourseLearning.Model.DTO.Enrollments;
using CourseLearning.Model.DTO.Lessons;
using CourseLearning.Model.Enrollments;
using CourseLearning.Model.Lessons;
using CourseLearning.Model.Questions;
using Course = CourseLearning.Model.Courses.Course;

namespace CourseLearning.Application.Mapper
{
    public class DtoMapperConfiguration
    {
        public static IMapper Mapper { get; set; }

        static DtoMapperConfiguration()
        {
            var config = new MapperConfiguration(ConfigureMapper);

            Mapper = config.CreateMapper();
        }

        private static void ConfigureMapper(IMapperConfigurationExpression config)
        {
            ConfigureCourseMap(config);
            ConfigureModuleMap(config);
            ConfigureUserMap(config);
            ConfigureLabelMap(config);
            ConfigureArticleMap(config);
            ConfigureStorageFolderMap(config);
            ConfigureStorageResourceMap(config);
            ConfigureQuizMap(config);
            ConfigureLessonMap(config);
            ConfigureEnrollmentMap(config);
        }

        private static void ConfigureCourseMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CourseDTO, Course>();
            configuration.CreateMap<Course, CourseDTO>();

            configuration.CreateMap<CourseTypeDTO, CourseType>();
            configuration.CreateMap<CourseType, CourseTypeDTO>();


            configuration.CreateMap<CourseSessionDTO, CourseSession>();
            configuration.CreateMap<CourseSession, CourseSessionDTO>();
        }

        private static void ConfigureModuleMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ModuleDTO, Module>();
            configuration.CreateMap<Module, ModuleDTO>();
        }

        private static void ConfigureUserMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<UserDTO, User>();
                //.ForMember(u => u.EnrollmentSessions, config => config.Ignore())
                //.ForMember(u => u.UserStorage, config => config.Ignore());
            configuration.CreateMap<User, UserDTO>();

            configuration.CreateMap<UserStorageDTO, UserStorage>();
            configuration.CreateMap<UserStorage, UserStorageDTO>();
        }

        private static void ConfigureLabelMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<LabelDTO, Label>();
            configuration.CreateMap<Label, LabelDTO>();
        }

        private static void ConfigureArticleMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ArticleDTO, Article>();
            configuration.CreateMap<Article, ArticleDTO>();
        }

        private static void ConfigureStorageFolderMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<StorageFolderDTO, StorageFolder>()
                                .ForMember(f => f.Resources, config => config.Ignore())
                                .ForMember(f => f.UserStorage, config => config.Ignore());
            configuration.CreateMap<StorageFolder, StorageFolderDTO>();
        }

        private static void ConfigureStorageResourceMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<StorageResourceDTO, StorageResource>();
            configuration.CreateMap<StorageResource, StorageResourceDTO>();
        }

        private static void ConfigureQuizMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<QuizDTO, Quiz>();
            configuration.CreateMap<Quiz, QuizDTO>();

            configuration.CreateMap<QuizQuestionDTO, QuizQuestion>();
            configuration.CreateMap<QuizQuestion, QuizQuestionDTO>();

            configuration.CreateMap<QuestionDTO, Question>();
            configuration.CreateMap<Question, QuestionDTO>();

            configuration.CreateMap<QuestionDTO, Question>();
            configuration.CreateMap<Question, QuestionDTO>();

            configuration.CreateMap<QuestionControlDTO, QuestionControl>();
            configuration.CreateMap<QuestionControl, QuestionControlDTO>();

            configuration.CreateMap<QuestionControlTypeDTO, QuestionControlType>();
            configuration.CreateMap<QuestionControlType, QuestionControlTypeDTO>();
        }

        private static void ConfigureLessonMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<LessonDTO, Lesson>();
            configuration.CreateMap<Lesson, LessonDTO>();

            configuration.CreateMap<LessonPageDTO, LessonPage>();
            configuration.CreateMap<LessonPage, LessonPageDTO>();

            configuration.CreateMap<LessonPageTypeDTO, LessonPageType>();
            configuration.CreateMap<LessonPageType, LessonPageTypeDTO>();

            configuration.CreateMap<LessonPageTransitionDTO, LessonPageTransition>();
            configuration.CreateMap<LessonPageTransition, LessonPageTransitionDTO>();

            configuration.CreateMap<LessonPageTransitionTypeDTO, LessonPageTransitionType>();
            configuration.CreateMap<LessonPageTransitionType, LessonPageTransitionTypeDTO>();
        }

        private static void ConfigureEnrollmentMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<EnrollmentSessionDTO, EnrollmentSession>();
            configuration.CreateMap<EnrollmentSession, EnrollmentSessionDTO>();

            configuration.CreateMap<EnrollmentSessionModuleDTO, EnrollmentSessionModule>();
            configuration.CreateMap<EnrollmentSessionModule, EnrollmentSessionModuleDTO>();

            configuration.CreateMap<EnrollmentSessionArticleDTO, EnrollmentSessionArticle>();
            configuration.CreateMap<EnrollmentSessionArticle, EnrollmentSessionArticleDTO>();

            configuration.CreateMap<EnrollmentSessionLessonDTO, EnrollmentSessionLesson>();
            configuration.CreateMap<EnrollmentSessionLesson, EnrollmentSessionLessonDTO>();

            configuration.CreateMap<EnrollmentSessionQuizDTO, EnrollmentSessionQuiz>();
            configuration.CreateMap<EnrollmentSessionQuiz, EnrollmentSessionQuizDTO>();

            configuration.CreateMap<EnrollmentSessionQuizQuestionDTO, EnrollmentSessionQuizQuestion>();
            configuration.CreateMap<EnrollmentSessionQuizQuestion, EnrollmentSessionQuizQuestionDTO>();

            configuration.CreateMap<QuestionAnswerDTO, QuestionAnswer>();
            configuration.CreateMap<QuestionAnswer, QuestionAnswerDTO>();

            configuration.CreateMap<QuestionControlAnswerDTO, QuestionControlAnswer>();
            configuration.CreateMap<QuestionControlAnswer, QuestionControlAnswerDTO>();

        }
    }
}