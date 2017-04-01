using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseLearning.Application.Interface;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;
using CourseLearning.Model.Courses;

namespace CourseLearning.Application
{
    public class CourseService : ICourseService
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

        public async Task<int> Add(Course course)
        {
            var tempUser = await Temp_InserUserAsync();
            if (tempUser == null)
            {
                throw new OperationCanceledException("user doesn't exist in database");
            }

            course.CreatorId = tempUser.UserId;       
            _unitOfWork.Courses.Add(course);
            await _unitOfWork.Complete();
            return _unitOfWork.Courses.GetLastId();
        }

        public async Task<Course> Get(int id)
        {
            return await _unitOfWork.Courses.Find(id);
        }

        public Task Delete(Course entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Course entity)
        {
            throw new NotImplementedException();
        }

        private async Task<User> Temp_InserUserAsync()
        {
            return await _unitOfWork.Users.GetAsync("testuser");
        }
    }
}
