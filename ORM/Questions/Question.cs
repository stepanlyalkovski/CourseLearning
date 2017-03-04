﻿using System.Collections.Generic;

namespace ORM.Questions
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string Text { get; set; }

        public string Category { get; set; }

        public IList<Label> Labels { get; set; }

        public virtual IList<QuestionControl> QuestionControlList { get; set; }
    }
}