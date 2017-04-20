using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLearning.Application.Interface;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application
{
    public class ModuleService : BaseEntityService<Module, ModuleDTO>, IModuleService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(ModuleDTO moduleDTO)
        {
            var module = ToEntity(moduleDTO);
            if (module.Course == null || module.Course.CourseId == 0)
            {
                throw new ArgumentNullException(nameof(module.Course));
            }

            var course = await _unitOfWork.Courses.FindAsync(module.Course.CourseId);
            if (course == null)
            {
                throw new ArgumentException("Course with current Id doesn't exist", nameof(module.Course.CourseId));
            }

            module.Course = course;
            _unitOfWork.Modules.Add(module);
            await _unitOfWork.CompleteAsync();
            return module.ModuleId;
        }

        public async Task<ModuleDTO> Get(int id)
        {
            var module = await _unitOfWork.Modules.FindAsync(id);
            return ToEntityDTO(module);
        }

        public Task Delete(ModuleDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(ModuleDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<ModuleDTO>> GetCourseModules(int courseId)
        {
            var modules = await _unitOfWork.Modules.GetCourseModules(courseId);
            return ToEntitiesDTO(modules);
        }

        public async Task AttachArticle(ArticleDTO article, int moduleId)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            var module = await _unitOfWork.Modules.FindAsync(moduleId);
            if (module == null)
            {
                throw new ArgumentException("Module with current id doesn't exist", nameof(moduleId));
            }

            var dbArticle = await _unitOfWork.Articles.FindAsync(article.ArticleId);
            if (article == null)
            {
                throw new ArgumentException("Article with current id doesn't exist", nameof(article.ArticleId));
            }

            _unitOfWork.Modules.AttachArticle(dbArticle, module);
            await _unitOfWork.CompleteAsync();
        }

    }
}