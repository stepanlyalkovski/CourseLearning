namespace CourseLearning.Model.DTO
{
    public class QuestionControlDTO
    {
        public int QuestionControlId { get; set; }

        public QuestionDTO Question { get; set; }

        public int QuestionId { get; set; }

        public string HeadingText { get; set; }

        public string AnswerValue { get; set; }

        public bool? IsRight { get; set; }
    }
}