using CourseLearning.Model.DTO.Lessons;

namespace CourseLearning.Model.DTO.Enrollments
{
    public class EnrollmentSessionLessonPageDTO
    {
        public int EnrollmentSessionLessonPageId { get; set; }

        public EnrollmentSessionLessonDTO EnrollmentSessionLesson { get; set; }

        public int EnrollmentSessionLessonId { get; set; }

        public LessonPageDTO LessonPage { get; set; }

        public int LessonPageId { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsCurrent { get; set; }

        public int PreviousLessonPageId { get; set; }
    }
}