using System.Collections.Generic;
using ORM.Courses;

namespace ORM.Enrollments
{
    public class EnrollmentSession
    {
        public int EnrollmentSessionId { get; set; }

        public bool IsCompleted { get; set; }

        public int CourseSessionId { get; set; }

        //public virtual CourseSession CourseSession { get; set; }

        public virtual User User { get; set; }

        //public virtual IList<EnrollmentSessionModule> EnrollmentSessionModules { get; set; }
    }
}