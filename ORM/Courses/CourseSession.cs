using System;

namespace ORM.Courses
{
    public class CourseSession
    {
        public int CourseSessionId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public virtual Course Course { get; set; }

    }
}