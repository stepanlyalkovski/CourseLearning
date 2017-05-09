using System.Collections.Generic;

namespace CourseLearning.Model.DTO
{
    public class CourseDTO
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CourseTypeDTO CourseType { get; set; }

        public IList<LabelDTO> Labels { get; set; }

        public IList<ModuleDTO> Modules { get; set; }

        public int CreatorId { get; set; }

        public UserDTO Creator { get; set; }
    }
}