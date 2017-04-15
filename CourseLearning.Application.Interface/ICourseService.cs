﻿using System;
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
        int Test();

        Task<IList<CourseDTO>> GetUserCreatedCoursesAsync(int userId);
    }
}
