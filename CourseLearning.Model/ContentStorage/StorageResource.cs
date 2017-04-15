using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CourseLearning.Model.Lessons;

namespace CourseLearning.Model.ContentStorage
{
    public class StorageResource
    {
        public int StorageResourceId { get; set; }

        public StorageFolder StorageFolder { get; set; }

        [ForeignKey("StorageFolder")]
        public int StorageFolderId { get; set; }

        public string MimeType { get; set; }

        public string Path { get; set; }

        public IList<LessonPage> LessonPages { get; set; }
    }
}