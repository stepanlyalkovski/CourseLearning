using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model.Lessons;

namespace CourseLearning.DAL.Interface
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        Task<IList<Lesson>> GetModuleLessonsAsync(int moduleId);

        void AddLessonPage(LessonPage lessonPage);
    }
}