using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model.Courses;

namespace CourseLearning.DAL
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext context) : base(context)
        {
        }

        public async Task<IList<Course>> GetUserCreateCoursesAsync(int userId)
        {
            return await Context.Set<Course>().Where(c => c.CreatorId == userId).ToListAsync();
        }
    }
}