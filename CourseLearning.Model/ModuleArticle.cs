namespace CourseLearning.Model
{
    public class ModuleArticle
    {
        public int ModuleArticleId { get; set; }
        public Module Module { get; set; }
        public Article Article { get; set; }
    }
}