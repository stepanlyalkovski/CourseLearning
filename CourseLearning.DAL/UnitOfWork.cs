using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;

namespace CourseLearning.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IRepositoryFactory _repositoryFactory;

        public ICourseRepository Courses { get; }

        public IModuleRepository Modules { get; }

        public IArticleRepository Articles { get; }

        public IStorageFolderRepository StorageFolders { get; }

        public IResourceRepository Resources { get; }

        public IQuizRepository Quizzes { get; }

        public IQuestionRepository Questions { get; }

        public ILessonRepository Lessons { get; }

        public IUserRepository Users { get; }

        public UnitOfWork(DbContext context, IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
            _context = context;

            Courses = repositoryFactory.CreateCourseRepository(context);
            Users = repositoryFactory.CreateUserRepository(context);
            Modules = repositoryFactory.CreateModuleRepository(context);
            Articles = repositoryFactory.CreateArticleRepository(context);
            StorageFolders = repositoryFactory.CreateStorageFolderRepository(context);
            Resources = repositoryFactory.CreateResourceRepository(context);
            Quizzes = repositoryFactory.CreateQuizRepository(context);
            Questions = repositoryFactory.CreateQuestionRepository(context);
            Lessons = repositoryFactory.CreateLessonRepository(context);
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}