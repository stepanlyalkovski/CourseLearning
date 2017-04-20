using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseLearning.Model.DTO
{
    public class QuizDTO
    {
        public int QuizId { get; set; }

        public int ModuleId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IList<QuizQuestionDTO> QuizQuestionList { get; set; } // create Count field

        public int TotalTimeSec { get; set; }

        public int PassNumber { get; set; }
    }
}
