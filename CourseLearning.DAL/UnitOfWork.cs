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

        public IUserRepository Users { get; }

        public UnitOfWork(DbContext context, IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
            _context = context;

            Courses = repositoryFactory.CreateCourseRepository(context);
            Users = repositoryFactory.CreateUserRepository(context);
        }

        private void InitializeRepositories(IRepositoryFactory repositoryFactory)
        {
            //Courses = repositoryFactory.CreateCourseRepository(_context);
        }


        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}