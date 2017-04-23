using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CourseLearning.Model;
using CourseLearning.Model.ContentStorage;
using CourseLearning.Model.Courses;
using CourseLearning.Model.Enrollments;
using CourseLearning.Model.Lessons;
using CourseLearning.Model.Questions;

namespace ORM
{
    public class CourseDbContext : DbContext
    {
        static CourseDbContext()
        {
                Database.SetInitializer(new CourseDbInitializer());
        }

        public CourseDbContext() : base("CourseDb")
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

    }
}