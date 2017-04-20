namespace CourseLearning.Model.Questions
{
    public class QuestionControl
    {
        public int QuestionControlId { get; set; }

        public Question Question { get; set; }

        public int QuestionId { get; set; }

        public string ControlHeading { get; set; }

        public string AnswerValue { get; set; }

        public bool? IsRight { get; set; }                   
    }
}