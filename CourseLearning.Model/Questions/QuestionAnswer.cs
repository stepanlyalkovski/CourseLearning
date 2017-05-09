using System.Collections.Generic;
using CourseLearning.Model.Enrollments;
using CourseLearning.Model.Lessons;

namespace CourseLearning.Model.Questions
{
    public class QuestionAnswer
    {
        public int QuestionAnswerId { get; set; }

        public bool IsRightAnswered { get; set; }

        public IList<QuestionControlAnswer> QuestionControlAnswerList { get; set; }
    }
}