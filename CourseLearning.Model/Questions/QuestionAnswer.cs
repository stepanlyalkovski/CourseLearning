using System.Collections.Generic;
using CourseLearning.Model.Lessons;

namespace CourseLearning.Model.Questions
{
    public class QuestionAnswer
    {
        public int QuestionAnswerId { get; set; }

        public bool IsRightAnswered { get; set; }

        public Question Question { get; set; }

        public int QuestionId { get; set; }

        public int? QuizId { get; set; }

        public Quiz Quiz { get; set; }

        public int? LessonId { get; set; }

        public Lesson Lesson { get; set; }

        public IList<QuestionControlAnswer> QuestionControlAnswerList { get; set; }
    }
}