using System.Collections.Generic;
using CourseLearning.Model.ContentStorage;
using CourseLearning.Model.Enrollments;

namespace CourseLearning.Model
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public virtual IList<EnrollmentSession> EnrollmentSessions { get; set; }

        public virtual UserStorage UserStorage { get; set; }
    }
}