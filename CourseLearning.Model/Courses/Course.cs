using System.Collections.Generic;

namespace CourseLearning.Model.Courses
{
    public class Course : BaseEntity
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public IList<Label> Labels { get; set; }

        public IList<Module> Modules { get; set; }
        
        public int CreatorId { get; set; }

        public User Creator { get; set; }
    }
}