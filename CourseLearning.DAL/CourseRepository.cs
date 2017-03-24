using System.Data.Entity;
using CourseLearning.DAL.Interface;
using CourseLearning.Model.Courses;

namespace CourseLearning.DAL
{
    public class CourseRepository : BaseRepository<Course, ORM.Courses.Course>
    {
        public CourseRepository(DbContext context) : base(context)
        {
        }

    }
}