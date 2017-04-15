using System.ComponentModel.DataAnnotations.Schema;

namespace CourseLearning.Model.Questions
{
    public class QuizQuestion
    {
        public int QuizQuestionId { get; set; }

        public int QuestionId { get; set; }

        public int QuizId { get; set; }

        [Column("SeqNum")]
        public int SequenceNumber { get; set; }

        public Question Question { get; set; }
      
        public Quiz Quiz { get; set; }
    }
}