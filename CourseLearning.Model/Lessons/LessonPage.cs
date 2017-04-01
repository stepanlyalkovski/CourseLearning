﻿using System.Collections.Generic;
using CourseLearning.Model.ContentStorage;
using CourseLearning.Model.Questions;

namespace CourseLearning.Model.Lessons
{
    public class LessonPage
    {
        public int LessonPageId { get; set; }

        public string Title { get; set; }

        public string MainText { get; set; }

        public virtual Lesson Lesson { get; set; }

        public int?  QuestionId { get; set; }
        
        public virtual Question Question { get; set; }

        public virtual IList<StorageResource> StorageResources { get; set; }

        public virtual LessonPageTransitionType LessonPageTransitionType { get; set; }

        public virtual IList<LessonPageTransition> LessonPageTransitions { get; set; }
    }
}