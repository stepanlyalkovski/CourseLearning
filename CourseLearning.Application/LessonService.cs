using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Application.Interface;
using CourseLearning.Application.Mapper;
using CourseLearning.DAL.Interface;
using CourseLearning.Model.DTO.Lessons;
using CourseLearning.Model.Lessons;

namespace CourseLearning.Application
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly DtoMapper<Lesson, LessonDTO> _lessonMapper = new DtoMapper<Lesson, LessonDTO>();

        private readonly DtoMapper<LessonPage, LessonPageDTO> _pageMapper = new DtoMapper<LessonPage, LessonPageDTO>();

        public LessonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(LessonDTO lessonDto)
        {

            ValidateLessonModule(lessonDto);
            //check user
            // check title uniqueness

            var lesson = _lessonMapper.ToEntity(lessonDto);
            _unitOfWork.Lessons.Add(lesson);
            await _unitOfWork.CompleteAsync();
            return lesson.LessonId;
        }

        public async Task<LessonDTO> Get(int id)
        {
           var lesson = await _unitOfWork.Lessons.FindAsync(id);
           return _lessonMapper.ToEntityDTO(lesson);
        }

        public Task Delete(LessonDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(LessonDTO lessonDto)
        {
            await _unitOfWork.Lessons.Update(_lessonMapper.ToEntity(lessonDto));
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IList<LessonDTO>> GetModuleLessons(int moduleId)
        {
            var lessons = await _unitOfWork.Lessons.GetModuleLessonsAsync(moduleId);
            return _lessonMapper.ToEntitiesDTO(lessons);
        }

        public async Task<LessonPageDTO> AddLessonPage(LessonPageDTO lessonPage)
        {
            if (lessonPage.LessonId == 0)
            {
                throw new ArgumentException("Lesson id is not specified", nameof(lessonPage.LessonId));
            }

            var lesson = await _unitOfWork.Lessons.FindAsync(lessonPage.LessonId);
            if (lesson == null)
            {
                throw new ArgumentException("Lesson with specified id doesn't exist", nameof(lessonPage.LessonId));
            }

            lessonPage.LessonPageTransitionType = LessonPageTransitionTypeDTO.Default;
            
            var page = _pageMapper.ToEntity(lessonPage);
            _unitOfWork.Lessons.AddLessonPage(page);
            await _unitOfWork.CompleteAsync();
            return _pageMapper.ToEntityDTO(page);
        }

        private async void ValidateLessonModule(LessonDTO lessonDto)
        {
            if (lessonDto == null)
            {
                throw new ArgumentNullException(nameof(lessonDto), "Lesson can't be null");
            }
            if (lessonDto.ModuleId == 0)
            {
                throw new ArgumentException("ModuleId is not specified", nameof(lessonDto.ModuleId));
            }

            var module = await _unitOfWork.Modules.FindAsync(lessonDto.ModuleId);
            if (module == null)
            {
                throw new ArgumentException("Module with specified id doesn't exist", nameof(lessonDto.ModuleId));
            }
        }
    }
}