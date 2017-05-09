using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseLearning.Model.Courses
{
    public class CourseSession
    {
        public int CourseSessionId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsStatic { get; set; }

        public Course Course { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
    }
}