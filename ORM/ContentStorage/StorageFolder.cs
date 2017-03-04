using System.Collections.Generic;

namespace ORM.ContentStorage
{
    public class StorageFolder
    {
        public int StorageFolderId { get; set; }

        public string Name { get; set; }

        public virtual UserStorage UserStorage { get; set; }

        public int UserStorageId { get; set; }

        public virtual IList<StorageResource> Resources { get; set; }

        public virtual IList<Article> Articles { get; set; }
    }
}