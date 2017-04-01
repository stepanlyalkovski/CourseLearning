using System.Data.Entity;
using ORM.ContentStorage;

namespace ORM
{
    public class CourseDbInitializer : CreateDatabaseIfNotExists<CourseDbContext>
    {
        protected override void Seed(CourseDbContext db)
        {
            User testuser = new User { Name = "testuser", UserStorage = new UserStorage { Name = "test user storage" } };
            db.Users.Add(testuser);
            db.SaveChanges();
            base.InitializeDatabase(db);
        }
    }
}