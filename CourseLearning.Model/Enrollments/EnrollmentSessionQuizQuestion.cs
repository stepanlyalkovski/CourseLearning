using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CourseLearning.Model.Questions;

namespace CourseLearning.Model.Enrollments
{
    public class EnrollmentSessionQuizQuestion
    {
        public int EnrollmentSessionQuizQuestionId { get; set; }

        public EnrollmentSessionQuiz EnrollmentSessionQuiz { get; set; }

        public int EnrollmentSessionQuizId { get; set; }

        public Question Question { get; set; }

        public int QuestionId { get; set; }

        public QuestionAnswer QuestionAnswer { get; set; }

        [ForeignKey("QuestionAnswer")]
        public int? QuestionAnswerId { get; set; }
    }
}