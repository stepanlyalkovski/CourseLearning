namespace ORM.Enrollments
{
    public class EnrollmentSessionArticle
    {
        public int EnrollmentSessionArticleId { get; set; }

        public bool IsCompleted { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public int EnrollmentSessionModuleId { get; set; }

        public virtual EnrollmentSessionModule EnrollmentSessionModule { get; set; }
    }
}