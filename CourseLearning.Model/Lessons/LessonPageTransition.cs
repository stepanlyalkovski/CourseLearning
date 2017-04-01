namespace CourseLearning.Model.Lessons
{
    public class LessonPageTransition
    {
        public int LessonPageTransitionId { get; set; }

        public LessonPage StartLessonPage { get; set; }

        public int StartPageId { get; set; }

        public int EndPageId { get; set; }

        public string CustomSignalValue { get; set; }

        public bool? YesNoSignal { get; set; }
    }
}