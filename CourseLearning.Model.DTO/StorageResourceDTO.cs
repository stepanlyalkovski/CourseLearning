using System.Collections.Generic;

namespace CourseLearning.Model.DTO
{
    public class StorageResourceDTO
    {
        public int StorageResourceId { get; set; }

        public StorageFolderDTO StorageFolder { get; set; }

        public int StorageFolderId { get; set; }

        public string MimeType { get; set; }

        public string Path { get; set; }

        //public IList<LessonPage> LessonPages { get; set; }
    }
}