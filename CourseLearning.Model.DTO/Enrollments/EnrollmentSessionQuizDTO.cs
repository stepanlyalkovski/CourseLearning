using System.Collections.Generic;

namespace CourseLearning.Model.DTO.Enrollments
{
    public class EnrollmentSessionQuizDTO
    {
        public int EnrollmentSessionQuizId { get; set; }

        public int QuizId { get; set; }

        public QuizDTO Quiz { get; set; }

        public int EnrollmentSessionModuleId { get; set; }

        public EnrollmentSessionModuleDTO EnrollmentSessionModule { get; set; }

        public EnrollmentSessionQuizQuestionDTO EnrollmentSessionQuizQuestion { get; set; }

        public bool IsCompleted { get; set; }
    }
}