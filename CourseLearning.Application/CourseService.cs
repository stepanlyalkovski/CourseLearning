using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using CourseLearning.Application.Helpers;
using CourseLearning.Application.Interface;
using CourseLearning.Application.Mapper;
using CourseLearning.DAL.Interface;
using CourseLearning.Model.Courses;
using CourseLearning.Model.DTO;
using User = CourseLearning.Model.User;

namespace CourseLearning.Application
{
    public class CourseService : BaseEntityService<Course, CourseDTO>, ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly DtoMapper<CourseSession, CourseSessionDTO> sessionMapper = new DtoMapper<CourseSession, CourseSessionDTO>();

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<CourseDTO>> GetUserCreatedCoursesAsync(int userId)
        {
            var courses = await _unitOfWork.Courses.GetUserCreatedCourses(userId);
            return ToEntitiesDTO(courses);
        }

        public async Task<int> CreateCourseSession(CourseSessionDTO courseSessionDto)
        {
            if (courseSessionDto.CourseId == 0)
            {
                throw new ArgumentException("Course id is not specified", nameof(courseSessionDto.CourseId));
            }

            var course = await _unitOfWork.Courses.FindAsync(courseSessionDto.CourseId);
            string userEmail = HttpContext.Current.User.Identity.Name;
            var dbUser = await _unitOfWork.Users.GetAsync(userEmail);

            int userId = dbUser.UserId;
            if (course.CreatorId != userId)
            {
                throw new ArgumentException("Course was created by another user so you can't create sessions for it");
            }

            if (course.CourseType == CourseType.StaticCourse)
            {
                throw new ArgumentException("Sessions can't be created for static course");
            }

            ValidateCourseSession(courseSessionDto);

            courseSessionDto.IsActive = courseSessionDto.StartDate.Date == DateTime.Today.Date;

            var courseSession = sessionMapper.ToEntity(courseSessionDto);
            _unitOfWork.Courses.CreateCourseSession(courseSession);
            await _unitOfWork.CompleteAsync();
            return courseSession.CourseSessionId;
        }

        public async Task UpdateActiveCourseSessions()
        {
            await _unitOfWork.Courses.UpdateCourseSessions();
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IList<CourseSessionDTO>> GetActiveCourseSessions()
        {
            var courseSessions = await _unitOfWork.Courses.GetCourseSessionsAsync();
            return sessionMapper.ToEntitiesDTO(courseSessions);
        }

        public async Task<IList<CourseSessionDTO>> GetUserCourseSessions()
        {
            var user = await UserHelper.GetCurrentUser(_unitOfWork);
            var sessions = await _unitOfWork.Courses.GetCourseSessionsAsync(user.UserId);
            return sessionMapper.ToEntitiesDTO(sessions);
        }

        public async Task<int> Add(CourseDTO courseDTO)
        {
            string userEmail = HttpContext.Current.User.Identity.Name;
            var dbUser = await _unitOfWork.Users.GetAsync(userEmail);
            if (dbUser == null)
            {
                throw new OperationCanceledException("user doesn't exist in database");
            }

            var course = ToEntity(courseDTO);
            course.CreatorId = dbUser.UserId;
            if (course.CourseType == CourseType.StaticCourse)
            {
                CreateStaticCourseSession(course);
            }

            _unitOfWork.Courses.Add(course);
            await _unitOfWork.CompleteAsync();

            return course.CourseId;
        }

        public async Task<CourseDTO> Get(int id)
        {

            var course = await _unitOfWork.Courses.FindAsync(id);
            return ToEntityDTO(course);
        }

        public async Task Delete(CourseDTO courseDto)
        {
            ValiteCourseCreator(courseDto);
            var course = ToEntity(courseDto);
            _unitOfWork.Courses.Delete(course);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Update(CourseDTO courseDto)
        {
            ValiteCourseCreator(courseDto);
            var course = ToEntity(courseDto);
            await _unitOfWork.Courses.Update(course);
            await _unitOfWork.CompleteAsync();
        }

        private void CreateStaticCourseSession(Course course)
        {
            var staticCourseSession = new CourseSession
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                IsStatic = true,
                IsActive = true,
                Course = course
            };

            _unitOfWork.Courses.CreateCourseSession(staticCourseSession);
        }

        private void ValidateCourseSession(CourseSessionDTO courseSession)
        {
            if (courseSession.IsStatic)
            {
                throw new ArgumentException("You can't create static course session");
            }

            if (courseSession.StartDate.ToUniversalTime().Millisecond < DateTime.UtcNow.Millisecond)
            {
                throw new ArgumentException("Start date is inalid. Date cannot be in the past", nameof(courseSession.StartDate));
            }

            if (DateTime.Compare(courseSession.StartDate, courseSession.EndDate) > 0)
            {
                throw new ArgumentException("End Date cannot happen earlier than Start Date", nameof(courseSession.EndDate));
            }
        }

        private async void ValiteCourseCreator(CourseDTO course)
        {
            var currentUser = await UserHelper.GetCurrentUser(_unitOfWork);
            if (currentUser.UserId != course.CreatorId)
            {
                throw new ArgumentException("Course doesn't belong to current user", nameof(course.Creator));
            }
        }
    }
}

