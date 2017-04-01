﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseLearning.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }

        IUserRepository Users { get; }

        Task<int> Complete();
    }
}
