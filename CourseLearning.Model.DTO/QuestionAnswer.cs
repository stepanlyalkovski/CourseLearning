using System.Collections.Generic;
using CourseLearning.Model.DTO.Enrollments;
using CourseLearning.Model.DTO.Lessons;

namespace CourseLearning.Model.DTO
{
    public class QuestionAnswerDTO
    {
        public int QuestionAnswerId { get; set; }

        public bool IsRightAnswered { get; set; }

        public IList<QuestionControlAnswerDTO> QuestionControlAnswerList { get; set; }
    }
}