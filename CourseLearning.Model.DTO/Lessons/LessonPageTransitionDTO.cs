namespace CourseLearning.Model.DTO.Lessons
{
    public class LessonPageTransitionDTO
    {
        public int LessonPageTransitionId { get; set; }

        public int StartPageId { get; set; }

        public int EndPageId { get; set; }

        public string CustomSignalValue { get; set; }

        public bool? YesNoSignal { get; set; }
    }
}