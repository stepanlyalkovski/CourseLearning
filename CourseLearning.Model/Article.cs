using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CourseLearning.Model.ContentStorage;

namespace CourseLearning.Model
{
    public class Article
    {
        public int ArticleId { get; set; }

        //TODO Check uniqueness in module
        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public User Creator { get; set; }

        [ForeignKey("Creator")]
        public int CreatorId { get; set; }

        //public int StorageFolderId { get; set; }

        //public StorageFolder StorageFolder { get; set; }

        public IList<Module> Modules { get; set; }
    }
}