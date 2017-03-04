using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ORM.Lessons;

namespace ORM.Enrollments
{
    public class EnrollmentSessionLesson
    {
        public int EnrollmentSessionLessonId { get; set; }

        public bool IsCompleted { get; set; }

        public EnrollmentSessionModule EnrollmentSessionModule { get; set; }

        [ForeignKey("EnrollmentSessionModule")]
        public int EnrollmentSessionModuleId { get; set; }

        public Lesson Lesson { get; set; }

        public int LessonId { get; set; }

        public virtual IList<EnrollmentSessionLessonPage> EnrollmentSessionLessonPages { get; set; }
    }
}