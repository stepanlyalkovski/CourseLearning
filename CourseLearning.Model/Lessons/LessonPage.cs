using System.Collections.Generic;
using CourseLearning.Model.ContentStorage;
using CourseLearning.Model.Questions;

namespace CourseLearning.Model.Lessons
{
    public class LessonPage
    {
        public int LessonPageId { get; set; }

        public string Title { get; set; }

        public string MainText { get; set; }

        public Lesson Lesson { get; set; }

        public int?  QuestionId { get; set; }
        
        public Question Question { get; set; }

        public IList<StorageResource> StorageResources { get; set; }

        public LessonPageTransitionType LessonPageTransitionType { get; set; }

        public IList<LessonPageTransition> LessonPageTransitions { get; set; }
    }
}