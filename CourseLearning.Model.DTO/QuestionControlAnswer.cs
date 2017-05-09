namespace CourseLearning.Model.DTO
{
    public class QuestionControlAnswerDTO
    {
        public int QuestionControlAnswerId { get; set; }

        public int QuestionControlId { get; set; }

        public QuestionControlDTO QuestionControl { get; set; }

        public int QuestionAnswerId { get; set; }

        public string StringAnswerValue { get; set; }

        public bool BoolAnswerValue { get; set; }

        public bool IsRightAnswered { get; set; }
    }
}