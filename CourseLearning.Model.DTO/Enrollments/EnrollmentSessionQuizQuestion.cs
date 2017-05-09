namespace CourseLearning.Model.DTO.Enrollments
{
    public class EnrollmentSessionQuizQuestionDTO
    {
        public int EnrollmentSessionQuizQuestionId { get; set; }

        public int EnrollmentSessionQuizId { get; set; }

        public QuestionDTO Question { get; set; }

        public int QuestionId { get; set; }

        public QuestionAnswerDTO QuestionAnswer { get; set; }

        public int? QuestionAnswerId { get; set; }
    }
}