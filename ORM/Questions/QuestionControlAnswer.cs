namespace ORM.Questions
{
    public class QuestionControlAnswer
    {
        public int QuestionControlAnswerId { get; set; }

        public int QuestionControlId { get; set; }

        public virtual QuestionControl QuestionControl { get; set; }

        public int QuestionAnswerId { get; set; }

        public virtual QuestionAnswer QuestionAnswer { get; set; }

        public string StringAnswerValue { get; set; }

        public bool BoolAnswerValue { get; set; }

        public bool IsRightAnswered { get; set; }
    }
}