using System.Collections.Generic;

namespace CourseLearning.Model.ContentStorage
{
    public class UserStorage
    {
        [ForeignKey("User")]
        public int UserStorageId { get; set; }

        public virtual User User { get; set; }

        public string Name { get; set; }

        public virtual IList<StorageFolder> StorageFolders { get; set; }
    }
}