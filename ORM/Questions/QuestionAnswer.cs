using System.Collections.Generic;

namespace ORM.Questions
{
    public class QuestionAnswer
    {
        public int QuestionAnswerId { get; set; }

        public bool IsRightAnswered { get; set; }

        public virtual IList<QuestionControlAnswer> QuestionControlAnswerList { get; set; }
    }
}