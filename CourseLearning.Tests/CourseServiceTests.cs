using System;
using System.Data.Entity;
using CourseLearning.Application;
using CourseLearning.Application.Interface;
using CourseLearning.DAL;
using CourseLearning.DAL.Interface;
using CourseLearning.Model.Courses;
using CourseLearning.Model.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CourseLearning.Tests
{
    [TestClass]
    public class CourseServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();

        private Mock<ICourseRepository> _courseRepositoryMock = new Mock<ICourseRepository>();

        private ICourseService _courseService;
        [TestInitialize]
        public void Init()
        {
            var courseStub = new Course();
            _courseRepositoryMock.Setup(c => c.FindAsync(It.IsAny<int>())).ReturnsAsync(courseStub);
            _unitOfWork.Setup(u => u.Courses).Returns(_courseRepositoryMock.Object);
            _courseService = new CourseService(_unitOfWork.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "End Date cannot happen earlier than Start Date")]
        public void AddCourseSession_StartDateIsInvalid_ValidationExceptionThrowned()
        {
            var invalidEndDate = DateTime.MinValue;
            var startDate = DateTime.Now;
            var courseSession = new CourseSessionDTO { EndDate = invalidEndDate, StartDate = startDate, CourseId = 1 };

            _courseService.CreateCourseSession(courseSession);
        }
    }
}
