using System;
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

        public async Task<IList<Course>> GetUserCreatedCourses(int userId)
        {
            return await Context.Set<Course>().Where(c => c.CreatorId == userId).ToListAsync();
        }

        public async Task<IList<CourseSession>> GetCourseSessionsAsync(bool isActive = true)
        {
            return await Context.Set<CourseSession>().Include(s => s.Course).Where(s => s.IsActive == isActive).ToListAsync();
        }

        public async Task<IList<CourseSession>> GetCourseSessionsAsync(int[] courseIds)
        {
            return await Context.Set<CourseSession>().Include(s => s.Course).Where(s => courseIds.Contains(s.CourseId)).ToListAsync();
        }

        public Task<IList<CourseSession>> GetCourseSessionsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public void CreateCourseSession(CourseSession courseSession)
        {
            Context.Set<CourseSession>().Add(courseSession);
        }

        private async Task<IList<CourseSession>> GetCourseSessions(DateTime? startDate, bool isActive, DateTime? endDate = null)
        {
            return await Context.Set<CourseSession>().Where(s => s.IsActive == isActive && 
            (!startDate.HasValue || s.StartDate.Date == startDate.Value.Date) &&
            (!endDate.HasValue || s.EndDate.Date == endDate.Value.Date)).ToListAsync();
        }

        public async Task UpdateCourseSessions()
        {
            var currentDate = DateTime.Today;
            var sessionsToActivate = await GetCourseSessions(currentDate, false);
            foreach (var courseSession in sessionsToActivate)
            {
                courseSession.IsActive = true;
            }

            var expiredSessions = await GetCourseSessions(null, true, currentDate);
            foreach (var session in expiredSessions)
            {
                session.IsActive = false;
            }
        }
    }
}