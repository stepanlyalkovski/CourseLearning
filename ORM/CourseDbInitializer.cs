using System.Collections.Generic;
using System.Data.Entity;
using CourseLearning.Model;
using CourseLearning.Model.ContentStorage;

namespace ORM
{
    public class CourseDbInitializer : CreateDatabaseIfNotExists<CourseDbContext>
    {
        protected override void Seed(CourseDbContext db)
        {
            StorageFolder mainFolder = new StorageFolder { Name = "Main", IsDefaultFolder = true };
            UserStorage storage = new UserStorage
            {
                Name = "test user storage",
                StorageFolders = new List<StorageFolder> { mainFolder }
            };

            User testuser = new User { Name = "testuser", UserStorage = storage };
            
            db.Users.Add(testuser);
            db.SaveChanges();
            base.InitializeDatabase(db);
        }
    }
}