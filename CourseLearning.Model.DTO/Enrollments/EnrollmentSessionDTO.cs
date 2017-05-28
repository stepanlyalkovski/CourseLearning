using System.Collections.Generic;

namespace CourseLearning.Model.DTO.Enrollments
{
    public class EnrollmentSessionDTO
    {
        public int EnrollmentSessionId { get; set; }

        public bool IsCompleted { get; set; }

        public int CourseSessionId { get; set; }

        public int UserId { get; set; }

        public IList<EnrollmentSessionModuleDTO> EnrollmentSessionModules { get; set; }
    }
}