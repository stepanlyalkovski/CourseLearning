using AutoMapper;

namespace CourseLearning.Model.Mapper
{
    public static class OrmMapper
    {
        public static IMapper Mapper { get; set; }

        static OrmMapper()
        {
            var config = new MapperConfiguration(ConfigureMapper);

            Mapper = config.CreateMapper();
        }

        private static void ConfigureMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<CourseLearning.Model.User, ORM.User>();
            config.CreateMap<CourseLearning.Model.Courses.Course, ORM.Courses.Course>();
        }
    }


}
