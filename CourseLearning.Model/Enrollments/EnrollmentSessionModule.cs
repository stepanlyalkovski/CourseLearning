using System.Collections.Generic;

namespace CourseLearning.Model.Enrollments
{
    public class EnrollmentSessionModule
    {
        public int EnrollmentSessionModuleId { get; set; }

        public int ModuleId { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsEnabled { get; set; }

        public int EnrollmentSessionId { get; set; }

        public EnrollmentSession EnrollmentSession { get; set; }

        public Module Module { get; set; }

        public IList<EnrollmentSessionArticle> EnrollmentSessionArticles { get; set; }

        public IList<EnrollmentSessionQuiz> EnrollmentSessionQuizzes { get; set; }

        public IList<EnrollmentSessionLesson> EnrollmentSessionLessons { get; set; }
    }
}