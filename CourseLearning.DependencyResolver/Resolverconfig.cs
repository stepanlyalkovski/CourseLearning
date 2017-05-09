using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseLearning.Application;
using CourseLearning.Application.Interface;
using CourseLearning.DAL;
using CourseLearning.DAL.Interface;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Web.Common;
using ORM;

namespace CourseLearning.DependencyResolver
{
    public static class Resolverconfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {

                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<CourseDbContext>().InRequestScope();
                
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<CourseDbContext>().InSingletonScope();
            }

            // Services

            kernel.Bind<ICourseService>().To<CourseService>();
            kernel.Bind<IModuleService>().To<ModuleService>();
            kernel.Bind<IArticleService>().To<ArticleService>();
            kernel.Bind<IStorageFolderService>().To<StorageFolderService>();
            kernel.Bind<IQuizService>().To<QuizService>();
            kernel.Bind<ILessonService>().To<LessonService>();
            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<IResourceService>().To<ResourceService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ICourseEnrollmentService>().To<EnrollmentService>();
            
            // Repositories

            kernel.Bind<ICourseRepository>().To<CourseRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IModuleRepository>().To<ModuleRepository>();
            kernel.Bind<IArticleRepository>().To<ArticleRepository>();
            kernel.Bind<IStorageFolderRepository>().To<StorageFolderRepository>();
            kernel.Bind<IResourceRepository>().To<ResourceRepository>();
            kernel.Bind<IQuizRepository>().To<QuizRepository>();
            kernel.Bind<IQuestionRepository>().To<QuestionRepository>();
            kernel.Bind<ILessonRepository>().To<LessonRepository>();
            kernel.Bind<IEnrollmentRepository>().To<EnrollmentRepository>();



            //Factories 

            kernel.Bind<IRepositoryFactory>().ToFactory(() => new TypeMatchingArgumentInheritanceInstanceProvider());
        }
    }
}
