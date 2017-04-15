using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseLearning.Model.Courses
{
    public class Course
    {
        public int CourseId { get; set; }

        [Index("CourseIndex", IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<Label> Labels { get; set; }

        public IList<Module> Modules { get; set; }

        public int CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public User Creator { get; set; }


    }
}