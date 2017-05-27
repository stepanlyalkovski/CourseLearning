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
        Task<IList<Course>> GetUserCreatedCourses(int userId);

        Task<IList<CourseSession>> GetCourseSessionsAsync(bool isActive = true);

        Task<IList<CourseSession>> GetCourseSessionsAsync(int[] courseIds);

        Task<IList<CourseSession>> GetCourseSessionsAsync(int userId);

        void CreateCourseSession(CourseSession courseSession);

        Task UpdateCourseSessions();
    }
}
