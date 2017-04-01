using System.Data.Entity;
using CourseLearning.DAL.Interface;
using CourseLearning.Model.Courses;

namespace CourseLearning.DAL
{
    public class CourseRepository : BaseRepository<Course, ORM.Courses.Course>, ICourseRepository
    {
        public CourseRepository(DbContext context) : base(context)
        {
        }

        //public override void Add(Course entity)
        //{
        //    var orm = ToOrmModel(entity);
        //    Context.Set<ORM.Courses.Course>().Add(orm);
        //}
    }
}