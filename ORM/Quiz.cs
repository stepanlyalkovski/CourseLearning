﻿using System.Collections.Generic;
using ORM.Questions;

namespace ORM
{
    public class Quiz
    {
        public int QuizId { get; set; }

        public virtual Module Module { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual IList<QuizQuestion> QuizQuestionList { get; set; }

        public int TotalTimeSec { get; set; }

        public int PassNumber { get; set; }
    }
}