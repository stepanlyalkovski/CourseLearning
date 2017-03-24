using System.Collections.Generic;
using CourseLearning.Model.Courses;
using CourseLearning.Model.Lessons;

namespace CourseLearning.Model
{
    public class Module
    {
        public int ModuleId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Course Course { get; set; }

        public virtual IList<Article> Articles { get; set; }

        public virtual IList<Quiz> Quizzes { get; set; }

        public virtual IList<Lesson> Lessons { get; set; }
    }
}