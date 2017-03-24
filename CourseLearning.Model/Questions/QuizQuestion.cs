namespace CourseLearning.Model.Questions
{
    public class QuizQuestion
    {
        public int QuizQuestionId { get; set; }

        public int QuestionId { get; set; }

        public int QuizId { get; set; }

        [Column("SeqNum")]
        public int SequenceNumber { get; set; }

        public virtual Question Question { get; set; }
      
        public virtual Quiz Quiz { get; set; }
    }
}