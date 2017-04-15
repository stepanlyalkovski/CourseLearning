using AutoMapper;
using CourseLearning.Model;
using CourseLearning.Model.ContentStorage;
using CourseLearning.Model.DTO;
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
        }

        private static void ConfigureCourseMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CourseDTO, Course>();
            configuration.CreateMap<Course, CourseDTO>();
        }

        private static void ConfigureModuleMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ModuleDTO, Module>();
            configuration.CreateMap<Module, ModuleDTO>();
        }

        private static void ConfigureUserMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<UserDTO, User>()
                .ForMember(u => u.EnrollmentSessions, config => config.Ignore())
                .ForMember(u => u.UserStorage, config => config.Ignore());
            configuration.CreateMap<User, UserDTO>();
        }

        private static void ConfigureLabelMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<LabelDTO, Label>();
            configuration.CreateMap<Label, LabelDTO>();
        }

        private static void ConfigureArticleMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<StorageArticleDTO, Article>();
            configuration.CreateMap<Article, StorageArticleDTO>();
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
    }
}