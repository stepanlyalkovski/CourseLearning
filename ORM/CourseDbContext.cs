using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ORM.ContentStorage;
using ORM.Courses;
using ORM.Enrollments;
using ORM.Lessons;
using ORM.Questions;

namespace ORM
{
    public class CourseDbContext : DbContext
    {
        static CourseDbContext()
        {
                //Database.SetInitializer(new DropCreateDatabaseAlways<CourseDbContext>());
        }

        public CourseDbContext() : base("ConsoleDb")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<CourseSession> CourseSessions { get; set; }

        public DbSet<EnrollmentSession> EnrollmentSessions { get; set; }

        public DbSet<EnrollmentSessionModule> EnrollmentSessionModules { get; set; }

        public DbSet<QuestionAnswer> QuestionAnsweres { get; set; }

        public DbSet<QuestionControlAnswer> QuestionControlAnsweres { get; set; }

        public DbSet<LessonPage> LessonPages { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<UserStorage> UserStorage { get; set; }

        public DbSet<ModuleArticle> ModuleArticles { get; set; }
    }
}