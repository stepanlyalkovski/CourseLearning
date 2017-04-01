using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseLearning.Model.Courses;

namespace CourseLearning.Application.Interface
{
    public interface ICourseService : IEntityService<Course>
    {
        int Test();
    }
}
