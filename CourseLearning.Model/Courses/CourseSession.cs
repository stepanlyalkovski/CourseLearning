using System;

namespace CourseLearning.Model.Courses
{
    public class CourseSession
    {
        public int CourseSessionId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public Course Course { get; set; }

    }
}