using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model.Enrollments;

namespace CourseLearning.DAL.Interface
{
    public interface IEnrollmentRepository : IRepository<EnrollmentSession>
    {
        Task<IList<EnrollmentSession>> GetUserEnrollments(int userId);

        Task<EnrollmentSession> GetCourseEnrollment(int userId, int courseSessionId);
    }
}