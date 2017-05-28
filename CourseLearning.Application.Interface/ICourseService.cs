using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseLearning.Model.Courses;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application.Interface
{
    public interface ICourseService : IEntityService<CourseDTO>
    {
        Task<IList<CourseDTO>> GetUserCreatedCoursesAsync(int userId);

        Task<int> CreateCourseSession(CourseSessionDTO courseSessionDto);

        Task UpdateActiveCourseSessions();

        Task<IList<CourseSessionDTO>> GetActiveCourseSessions();

        Task<IList<CourseSessionDTO>> GetUserCourseSessions();
    }
}
