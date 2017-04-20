namespace CourseLearning.Model.DTO
{
    public class QuestionControlDTO
    {
        public int QuestionControlId { get; set; }

        public int QuestionId { get; set; }

        public string ControlHeading { get; set; }

        public string AnswerValue { get; set; }

        public bool? IsRight { get; set; }
    }
}