using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model.Enrollments;

namespace CourseLearning.DAL
{
    public class EnrollmentRepository : BaseRepository<EnrollmentSession>, IEnrollmentRepository
    {
        public EnrollmentRepository(DbContext context) : base(context)
        {
        }

        public async Task<IList<EnrollmentSession>> GetUserEnrollments(int userId)
        {
            return await Context.Set<EnrollmentSession>()
                .Include(s => s.EnrollmentSessionModules)
                .Where(s => s.UserId == userId).ToListAsync();
        }

        public async Task<EnrollmentSession> GetCourseEnrollment(int userId, int courseSessionId)
        {
            return await Context.Set<EnrollmentSession>()
                .Include(s => s.EnrollmentSessionModules.Select(m => m.EnrollmentSessionArticles))
                .Include(s => s.EnrollmentSessionModules.Select(m => m.EnrollmentSessionLessons))
                .Include(s => s.EnrollmentSessionModules.Select(m => m.EnrollmentSessionQuizzes))
                .FirstOrDefaultAsync(s => s.UserId == userId && s.CourseSessionId == courseSessionId);
        }
    }
}