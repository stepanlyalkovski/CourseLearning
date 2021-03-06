﻿using System.Collections.Generic;
using System.Reflection.Emit;

namespace CourseLearning.Model.DTO
{
    public class QuestionDTO
    {
        public int QuestionId { get; set; }

        public string QuestionHeading { get; set; }

        public string Category { get; set; }

        public int CreatorId { get; set; }

        public QuestionControlTypeDTO QuestionControlType { get; set; }

        public IList<LabelDTO> Labels { get; set; }

        public IList<QuestionControlDTO> ControlList { get; set; }
    }
}