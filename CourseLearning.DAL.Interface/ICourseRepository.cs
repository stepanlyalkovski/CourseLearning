using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseLearning.Model.Courses;

namespace CourseLearning.DAL.Interface
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IList<Course>> GetUserCreateCoursesAsync(int userId);
    }
}
