using System.Data.Entity;
using CourseLearning.DAL.Interface;

namespace CourseLearning.DAL
{
    public interface IRepositoryFactory
    {
        ICourseRepository CreateCourseRepository(DbContext contex);

        IUserRepository CreateUserRepository(DbContext context);

        IModuleRepository CreateModuleRepository(DbContext context);

        IArticleRepository CreateArticleRepository(DbContext context);

        IStorageFolderRepository CreateStorageFolderRepository(DbContext context);

        IResourceRepository CreateResourceRepository(DbContext context);

        IQuizRepository CreateQuizRepository(DbContext context);

        IQuestionRepository CreateQuestionRepository(DbContext context);
    }
}
