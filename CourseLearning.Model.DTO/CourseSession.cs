using System;

namespace CourseLearning.Model.DTO
{
    public class CourseSessionDTO
    {
        public int CourseSessionId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsStatic { get; set; }

        public int CourseId { get; set; }

        public CourseDTO Course { get; set; }
    }
}