using System.Collections.Generic;

namespace CourseLearning.Model.DTO
{
    public class ModuleDTO
    {
        public int ModuleId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CourseDTO Course { get; set; }

        public IList<StorageArticleDTO> Articles { get; set; }

        public IList<QuizDTO> Quizzes { get; set; }

        //public IList<Lesson> Lessons { get; set; }
    }
}