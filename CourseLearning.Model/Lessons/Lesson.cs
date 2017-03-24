using System.Collections.Generic;

namespace CourseLearning.Model.Lessons
{
    public class Lesson
    {
        public int LessonId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual Module Module { get; set; }

        public virtual IList<LessonPage> LessonPages { get; set; }

        public int? FirstPageId { get; set; }

        public int? LastPageId { get; set; }
    }
}