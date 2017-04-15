using System.Collections.Generic;

namespace CourseLearning.Model.DTO
{
    public class StorageArticleDTO
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int StorageFolderId { get; set; }
    }
}