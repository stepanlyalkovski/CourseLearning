using System.Collections.Generic;
using ORM.ContentStorage;

namespace ORM.Lessons
{
    public class LessonPage
    {
        public int LessonPageId { get; set; }

        public string Title { get; set; }

        public string MainText { get; set; }

        public virtual Lesson Lesson { get; set; }

        public virtual IList<StorageResource> StorageResources { get; set; }

        public virtual LessonPageTransitionType LessonPageTransitionType { get; set; }

        public virtual IList<LessonPageTransition> LessonPageTransitions { get; set; }
    }
}