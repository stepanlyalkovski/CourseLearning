using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseLearning.Model.Questions
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string QuestionHeading { get; set; }

        public string Category { get; set; }

        public User Creator { get; set; }

        [ForeignKey("Creator")]
        public int CreatorId { get; set; }

        public QuestionControlType QuestionControlType { get; set; } 

        public IList<Label> Labels { get; set; }

        public IList<QuestionControl> ControlList { get; set; }
    }
}