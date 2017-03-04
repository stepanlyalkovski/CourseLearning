using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ORM.Lessons;

namespace ORM.ContentStorage
{
    public class StorageResource
    {
        public int StorageResourceId { get; set; }

        public virtual StorageFolder StorageFolder { get; set; }

        [ForeignKey("StorageFolder")]
        public int StorageFolderId { get; set; }

        public string MimeType { get; set; }

        public string Path { get; set; }

        public IList<LessonPage> LessonPages { get; set; }
    }
}