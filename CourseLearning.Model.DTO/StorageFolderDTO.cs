using System.Collections.Generic;

namespace CourseLearning.Model.DTO
{
    public class StorageFolderDTO
    {
        public int StorageFolderId { get; set; }

        public string Name { get; set; }

        //public UserStorage UserStorage { get; set; }

        public int UserStorageId { get; set; }

        public IList<StorageResourceDTO> Resources { get; set; }

        public IList<ArticleDTO> Articles { get; set; }

        public bool IsDefaultFolder { get; set; }
    }
}