using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CourseLearning.Model.Courses;
using CourseLearning.Model.Lessons;

namespace CourseLearning.Model
{
    public class Module
    {
        public int ModuleId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Course Course { get; set; }

        public IList<Article> Articles { get; set; }

        public IList<Quiz> Quizzes { get; set; }

        public IList<Lesson> Lessons { get; set; }
    }
}