using System.Collections.Generic;

namespace CourseLearning.Model.DTO.Enrollments
{
    public class EnrollmentSessionModuleDTO
    {
        public int EnrollmentSessionModuleId { get; set; }

        public int ModuleId { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsEnabled { get; set; }

        public int EnrollmentSessionId { get; set; }

        public ModuleDTO Module { get; set; }

        public IList<EnrollmentSessionArticleDTO> EnrollmentSessionArticles { get; set; }

        public IList<EnrollmentSessionQuizDTO> EnrollmentSessionQuizzes { get; set; }

        public IList<EnrollmentSessionLessonDTO> EnrollmentSessionLessons { get; set; }
    }
}