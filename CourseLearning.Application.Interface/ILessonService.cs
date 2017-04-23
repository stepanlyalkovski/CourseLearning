using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model.DTO.Lessons;

namespace CourseLearning.Application.Interface
{
    public interface ILessonService : IEntityService<LessonDTO>
    {
        Task<IList<LessonDTO>> GetModuleLessons(int moduleId);

        Task<LessonPageDTO> AddLessonPage(LessonPageDTO lessonPage);
    }
}