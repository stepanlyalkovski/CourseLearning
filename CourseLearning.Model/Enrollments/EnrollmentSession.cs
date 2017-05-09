using System.Collections.Generic;
using CourseLearning.Model.Courses;

namespace CourseLearning.Model.Enrollments
{
    public class EnrollmentSession
    {
        public int EnrollmentSessionId { get; set; }

        public bool IsCompleted { get; set; }

        public int CourseSessionId { get; set; }

        public CourseSession CourseSession { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public IList<EnrollmentSessionModule> EnrollmentSessionModules { get; set; }
    }
}