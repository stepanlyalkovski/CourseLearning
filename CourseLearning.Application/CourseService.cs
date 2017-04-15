using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Test()
        {
            Debug.Write("-------------------- Test debug write!!! --------------------");
            return 999;
        }

        public async Task<IList<CourseDTO>> GetUserCreatedCoursesAsync(int userId)
        {
            var courses = await _unitOfWork.Courses.GetUserCreateCoursesAsync(userId);
            return ToEntitiesDTO(courses);
        }

        public async Task<int> Add(CourseDTO courseDTO)
        {            
            var tempUser = await Temp_InserUserAsync();
            if (tempUser == null)
            {
                throw new OperationCanceledException("user doesn't exist in database");
            }

            var course = ToEntity(courseDTO);
            course.CreatorId = tempUser.UserId;       
            _unitOfWork.Courses.Add(course);
            await _unitOfWork.CompleteAsync();
            return course.CourseId;
        }

        public async Task<CourseDTO> Get(int id)
        {
            var course = await _unitOfWork.Courses.FindAsync(id);
            return ToEntityDTO(course);
        }

        public Task Delete(CourseDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(CourseDTO entity)
        {
            throw new NotImplementedException();
        }

        private async Task<User> Temp_InserUserAsync()
        {
            return await _unitOfWork.Users.GetAsync("testuser");
        }
    }
}
