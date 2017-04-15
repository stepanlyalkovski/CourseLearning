namespace CourseLearning.Model.Enrollments
{
    public class EnrollmentSessionArticle
    {
        public int EnrollmentSessionArticleId { get; set; }

        public bool IsCompleted { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public int EnrollmentSessionModuleId { get; set; }

        public EnrollmentSessionModule EnrollmentSessionModule { get; set; }
    }
}