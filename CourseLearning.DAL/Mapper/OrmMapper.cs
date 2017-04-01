using AutoMapper;

namespace CourseLearning.DAL.Mapper
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
            config.CreateMap<CourseLearning.Model.User, ORM.User>();//.ForMember(m => m.EnrollmentSessions, opt => opt.Ignore());
            config.CreateMap<CourseLearning.Model.ContentStorage.UserStorage, ORM.ContentStorage.UserStorage>();
            config.CreateMap<CourseLearning.Model.Courses.Course, ORM.Courses.Course>();

            config.CreateMap<CourseLearning.Model.Enrollments.EnrollmentSession, ORM.Enrollments.EnrollmentSession>();
        }
    }


}
