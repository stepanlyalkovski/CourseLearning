using CourseLearning.Model.Lessons;

namespace CourseLearning.Model.Enrollments
{
    public class EnrollmentSessionLessonPage
    {
        public int EnrollmentSessionLessonPageId { get; set; }

        public EnrollmentSessionLesson EnrollmentSessionLesson { get; set; }

        [ForeignKey("EnrollmentSessionLesson")]
        public int EnrollmentSessionLessonId { get; set; }

        public LessonPage LessonPage { get; set; }

        public int LessonPageId { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsCurrent { get; set; }

        public int PreviousLessonPageId { get; set; }
    }
}