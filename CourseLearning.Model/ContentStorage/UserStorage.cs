using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseLearning.Model.ContentStorage
{
    public class UserStorage
    {
        [ForeignKey("User")]
        public int UserStorageId { get; set; }

        public virtual User User { get; set; }

        public string Name { get; set; }

        public IList<StorageFolder> StorageFolders { get; set; }
    }
}