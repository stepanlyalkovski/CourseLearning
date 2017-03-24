namespace CourseLearning.Model
{
    public class ModuleArticle
    {
        public int ModuleArticleId { get; set; }
        public virtual Module Module { get; set; }
        public virtual Article Article { get; set; }
    }
}