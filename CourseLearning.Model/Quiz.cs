using System.Collections.Generic;
using CourseLearning.Model.Questions;

namespace CourseLearning.Model
{
    public class Quiz
    {
        public int QuizId { get; set; }

        public Module Module { get; set; }

        public int ModuleId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IList<QuizQuestion> QuizQuestionList { get; set; }

        public int TotalTimeSec { get; set; }

        public int PassNumber { get; set; }
    }
}