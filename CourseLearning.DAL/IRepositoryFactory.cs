using System.Data.Entity;
using CourseLearning.DAL.Interface;

namespace CourseLearning.DAL
{
    public interface IRepositoryFactory
    {
        ICourseRepository CreateCourseRepository(DbContext contex);

        IUserRepository CreateUserRepository(DbContext context);
    }
}
