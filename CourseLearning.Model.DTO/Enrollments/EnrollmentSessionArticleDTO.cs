namespace CourseLearning.Model.DTO.Enrollments
{
    public class EnrollmentSessionArticleDTO
    {
        public int EnrollmentSessionArticleId { get; set; }

        public bool IsCompleted { get; set; }

        public int ArticleId { get; set; }

        public int EnrollmentSessionModuleId { get; set; }
    }
}