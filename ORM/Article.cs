using System.Collections.Generic;
using ORM.ContentStorage;

namespace ORM
{
    public class Article
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int StorageFolderId { get; set; }

        public StorageFolder StorageFolder { get; set; }

        public virtual IList<Module> Modules { get; set; }
    }
}