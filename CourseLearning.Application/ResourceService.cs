using System;
using System.Threading.Tasks;
using CourseLearning.Application.Interface;
using CourseLearning.Application.Mapper;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;
using CourseLearning.Model.ContentStorage;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application
{
    public class ResourceService : IResourceService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly DtoMapper<StorageResource, StorageResourceDTO> _resourceMapper = new DtoMapper<StorageResource, StorageResourceDTO>();

        public ResourceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(StorageResourceDTO resource)
        {
            //TODO validate User

            if (resource.StorageFolderId == 0)
            {
                throw new ArgumentException("storage folder is not specified", nameof(resource.StorageFolderId));
            }

            var newResource = _resourceMapper.ToEntity(resource);
            _unitOfWork.Resources.Add(newResource);
            await _unitOfWork.CompleteAsync();
            return newResource.StorageResourceId;
        }

        public Task<StorageResourceDTO> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(StorageResourceDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(StorageResourceDTO entity)
        {
            throw new System.NotImplementedException();
        }
    }
}