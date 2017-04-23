using System.Collections.Generic;

namespace CourseLearning.Model.DTO.Lessons
{
    public class LessonPageDTO
    {
        public int LessonPageId { get; set; }

        public LessonPageTypeDTO LessonPageType { get; set; }

        public string Title { get; set; }

        public string MainText { get; set; }

        public int LessonId { get; set; }

        public int?  QuestionId { get; set; }
        
        public QuestionDTO Question { get; set; }

        public IList<StorageResourceDTO> StorageResources { get; set; }

        public LessonPageTransitionTypeDTO LessonPageTransitionType { get; set; }

        public IList<LessonPageTransitionDTO> LessonPageTransitions { get; set; }
    }
}