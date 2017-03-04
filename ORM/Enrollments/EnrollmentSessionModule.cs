using System.Collections.Generic;

namespace ORM.Enrollments
{
    public class EnrollmentSessionModule
    {
        public int EnrollmentSessionModuleId { get; set; }

        public int ModuleId { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsEnabled { get; set; }

        public int EnrollmentSessionId { get; set; }

        public virtual EnrollmentSession EnrollmentSession { get; set; }

        public virtual Module Module { get; set; }

        public virtual IList<EnrollmentSessionArticle> EnrollmentSessionArticles { get; set; }

        public virtual IList<EnrollmentSessionQuiz> EnrollmentSessionQuizzes { get; set; }

        public virtual IList<EnrollmentSessionLesson> EnrollmentSessionLessons { get; set; }
    }
}