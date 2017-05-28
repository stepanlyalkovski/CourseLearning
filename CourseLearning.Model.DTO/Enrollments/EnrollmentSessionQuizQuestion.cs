namespace CourseLearning.Model.DTO.Enrollments
{
    public class EnrollmentSessionQuizQuestionDTO
    {
        public int EnrollmentSessionQuizQuestionId { get; set; }

        public int EnrollmentSessionQuizId { get; set; }

        public int QuestionId { get; set; }

        public int? QuestionAnswerId { get; set; }
    }
}