using AutoMapper;

namespace CourseLearning.DAL.Mapper
{
    public class TestMapper
    {
        public static IMapper Mapper { get; set; }

        static TestMapper()
        {
            var config = new MapperConfiguration(ConfigureMapper);

            Mapper = config.CreateMapper();
        }

        private static void ConfigureMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<CourseLearning.Model.Label, ORM.Label>();
        }
    }
}