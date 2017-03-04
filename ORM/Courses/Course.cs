using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Courses
{
    public class Course
    {
        public int CourseId { get; set; }

        [Index("CourseIndex", IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }

        public IList<Label> Labels { get; set; }

        public virtual IList<Module> Modules { get; set; }
        
        public int CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }
    }
}