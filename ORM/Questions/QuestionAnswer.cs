﻿using System.Collections.Generic;
using ORM.Lessons;

namespace ORM.Questions
{
    public class QuestionAnswer
    {
        public int QuestionAnswerId { get; set; }

        public bool IsRightAnswered { get; set; }

        public virtual Question Question { get; set; }

        public int QuestionId { get; set; }

        public int? QuizId { get; set; }

        public Quiz Quiz { get; set; }

        public int? LessonId { get; set; }

        public Lesson Lesson { get; set; }

        public virtual IList<QuestionControlAnswer> QuestionControlAnswerList { get; set; }
    }
}