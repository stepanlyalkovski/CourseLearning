using System.Collections.Generic;

namespace CourseLearning.Model.DTO
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public int CreatorId { get; set; }
    }
}