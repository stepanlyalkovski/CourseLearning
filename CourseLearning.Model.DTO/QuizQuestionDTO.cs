namespace CourseLearning.Model.DTO
{
    public class QuizQuestionDTO
    {
        public int QuizQuestionId { get; set; }

        public int QuestionId { get; set; }

        public int QuizId { get; set; }

        public int SequenceNumber { get; set; }

        public QuestionDTO Question { get; set; }
    }
}