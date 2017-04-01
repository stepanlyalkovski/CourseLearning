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

            kernel.Bind<ICourseService>().To<CourseService>();
            kernel.Bind<ICourseRepository>().To<CourseRepository>();

            //kernel.Bind<IUserService>().To<Userse>();
            kernel.Bind<IUserRepository>().To<UserRepository>();

            kernel.Bind<IRepositoryFactory>().ToFactory(() => new TypeMatchingArgumentInheritanceInstanceProvider());

            //kernel.Bind<IUserRepository>().To<UserRepository>();
            //kernel.Bind<IRoleRepository>().To<RoleRepository>();
            //kernel.Bind<IProfileRepository>().To<ProfileRepository>();
            //kernel.Bind<IStorageRepository>().To<StorageRepository>();
            //kernel.Bind<ICourseRepository>().To<CourseRepository>();
            //kernel.Bind<IModuleRepository>().To<ModuleRepository>();
            //kernel.Bind<ILessonRepository>().To<LessonRepository>();
            //kernel.Bind<IQuizRepository>().To<QuizRepository>();
            //kernel.Bind<IHtmlArticleRepository>().To<HtmlArticleRepository>();
            //kernel.Bind<ILessonPageRepository>().To<LessonPageRepository>();
            //kernel.Bind<IImageRepository>().To<ImageRepository>();
            //kernel.Bind<ICodeSampleRepository>().To<CodeSampleRepository>();
            //kernel.Bind<IEnrolmentRepository>().To<EnrolmentRepository>();
            //kernel.Bind<ICourseProgressRepository>().To<CourseProgressRepository>();
            //kernel.Bind<ITagRepository>().To<TagRepository>();

            //kernel.Bind<IRepositoryFactory>().ToFactory();

            //kernel.Bind<IUserService>().To<UserService>();
            //kernel.Bind<IRoleService>().To<RoleService>();
            //kernel.Bind<IStorageService>().To<StorageService>();
            //kernel.Bind<IProfileService>().To<ProfileService>();
            //kernel.Bind<ICourseService>().To<CourseService>();
            //kernel.Bind<IModuleService>().To<ModuleService>();
            //kernel.Bind<ILessonService>().To<LessonService>();
            //kernel.Bind<IEnrolmentService>().To<EnrolmentService>();
            //kernel.Bind<ILessonPageService>().To<LessonPageService>();
        }
    }
}
