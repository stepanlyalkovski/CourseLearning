using System.Collections.Generic;
using ORM.Courses;
using ORM.Lessons;

namespace ORM
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