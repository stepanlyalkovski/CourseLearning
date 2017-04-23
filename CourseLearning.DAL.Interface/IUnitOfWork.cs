using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseLearning.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }

        IUserRepository Users { get; }

        IModuleRepository Modules { get; }

        IArticleRepository Articles { get; }

        IStorageFolderRepository StorageFolders { get; }

        IResourceRepository Resources { get; }

        IQuizRepository Quizzes { get; }

        IQuestionRepository Questions { get; }

        ILessonRepository Lessons { get; }

        Task<int> CompleteAsync();
    }
}
