using System.Collections.Generic;

namespace CourseLearning.Model.DTO
{
    public class UserStorageDTO
    {
        public int UserStorageId { get; set; }

        public virtual UserDTO User { get; set; }

        public string Name { get; set; }

        public IList<StorageFolderDTO> StorageFolders { get; set; }
    }
}