using AutoMapper;

namespace CourseLearning.DAL.Mapper
{
    public class DalMapper
    {
        public static IMapper Mapper { get; set; }

        static DalMapper()
        {
            var config = new MapperConfiguration(ConfigureMapper);

            Mapper = config.CreateMapper();
        }

        private static void ConfigureMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<ORM.User, CourseLearning.Model.User>();
            config.CreateMap<ORM.Courses.Course, CourseLearning.Model.Courses.Course>();
        }
    }
}