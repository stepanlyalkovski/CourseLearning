using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Application.Helpers;
using CourseLearning.Application.Interface;
using CourseLearning.Application.Mapper;
using CourseLearning.DAL.Interface;
using CourseLearning.Model.DTO.Enrollments;
using CourseLearning.Model.Enrollments;

namespace CourseLearning.Application
{
    public class EnrollmentService : ICourseEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly DtoMapper<EnrollmentSession, EnrollmentSessionDTO> _sessionMapper = new DtoMapper<EnrollmentSession, EnrollmentSessionDTO>();

        public EnrollmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<EnrollmentSessionDTO>> GetUserEnrollments()
        {
            var user = await UserHelper.GetCurrentUser();
            var session = await _unitOfWork.Enrollments.GetUserEnrollments(user.UserId);
            return _sessionMapper.ToEntitiesDTO(session);
        }

        public async Task<EnrollmentSessionDTO> GetCourseEnrollment(int courseSessionId)
        {
            var user = await UserHelper.GetCurrentUser();
            var session = await _unitOfWork.Enrollments.GetCourseEnrollment(user.UserId, courseSessionId);
            return _sessionMapper.ToEntityDTO(session);
        }
    }
}