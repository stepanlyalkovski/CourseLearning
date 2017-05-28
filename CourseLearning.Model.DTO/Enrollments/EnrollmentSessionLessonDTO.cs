using System.Collections.Generic;
using CourseLearning.Model.DTO.Lessons;

namespace CourseLearning.Model.DTO.Enrollments
{
    public class EnrollmentSessionLessonDTO
    {
        public int EnrollmentSessionLessonId { get; set; }

        public bool IsCompleted { get; set; }

        public int EnrollmentSessionModuleId { get; set; }

        public int LessonId { get; set; }

        public IList<EnrollmentSessionLessonPageDTO> EnrollmentSessionLessonPages { get; set; }
    }
}