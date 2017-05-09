using System.Collections.Generic;
using CourseLearning.Model.Questions;

namespace CourseLearning.Model.Enrollments
{
    public class EnrollmentSessionQuiz
    {
        public int EnrollmentSessionQuizId { get; set; }

        public int QuizId { get; set; }

        public Quiz Quiz { get; set; }

        public int EnrollmentSessionModuleId { get; set; }

        public EnrollmentSessionModule EnrollmentSessionModule { get; set; }

        public IList<EnrollmentSessionQuizQuestion> EnrollmentSessionQuizQuestions { get; set; }

        public bool IsCompleted { get; set; }
    }
}