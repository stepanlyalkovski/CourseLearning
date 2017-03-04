using System.Collections.Generic;
using ORM.ContentStorage;
using ORM.Enrollments;

namespace ORM
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public virtual IList<EnrollmentSession> EnrollmentSessions { get; set; }

        public virtual UserStorage UserStorage { get; set; }
    }
}