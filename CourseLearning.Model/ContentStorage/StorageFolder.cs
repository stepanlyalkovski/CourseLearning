using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseLearning.Model.ContentStorage
{
    public class StorageFolder
    {
        public int StorageFolderId { get; set; }

        [Index("StorageFolderIndex", IsUnique = true)]
        [MaxLength(25)]
        public string Name { get; set; }

        public UserStorage UserStorage { get; set; }

        public int UserStorageId { get; set; }

        public IList<StorageResource> Resources { get; set; }

        public IList<Article> Articles { get; set; }

        public bool IsDefaultFolder { get; set; }
    }
}