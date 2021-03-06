﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model.DTO.Enrollments;
using CourseLearning.Model.Enrollments;

namespace CourseLearning.Application.Interface
{
    public interface IEnrollmentService
    {
        Task<IList<EnrollmentSessionDTO>> GetUserEnrollments();

        Task<EnrollmentSessionDTO> GetCourseEnrollment(int courseSessionId);

        Task<EnrollmentSessionDTO> CreateEnrollment(int courseSessionId);
    }
}