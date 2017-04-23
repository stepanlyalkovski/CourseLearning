using System.Collections.Generic;

namespace CourseLearning.Model.DTO.Lessons
{
    public class LessonDTO
    {
        public int LessonId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ModuleId { get; set; }

        public IList<LessonPageDTO> LessonPages { get; set; }

        public int? FirstPageId { get; set; }

        public int? LastPageId { get; set; }
    }
}