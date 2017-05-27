using System;
using System.Threading.Tasks;
using System.Web;
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
                var user = await _unitOfWork.Users.GetAsync(HttpContext.Current.User.Identity.Name);
                var mainFolder = await _unitOfWork.StorageFolders.GetMainFolderAsync(user.UserId);
                resource.StorageFolderId = mainFolder.StorageFolderId;
            }

            var newResource = _resourceMapper.ToEntity(resource);
            _unitOfWork.Resources.Add(newResource);
            await _unitOfWork.CompleteAsync();
            return newResource.StorageResourceId;
        }

        public async Task<StorageResourceDTO> Get(int id)
        {
            var resource = await _unitOfWork.Resources.FindAsync(id);
            return _resourceMapper.ToEntityDTO(resource);
        }

        public Task Delete(StorageResourceDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(StorageResourceDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<StorageResourceDTO> AddResource(StorageResourceDTO storageResourceDto)
        {
            if (storageResourceDto.StorageFolderId == 0)
            {
                var user = await _unitOfWork.Users.GetAsync(HttpContext.Current.User.Identity.Name);
                var mainFolder = await _unitOfWork.StorageFolders.GetMainFolderAsync(user.UserId);
                storageResourceDto.StorageFolderId = mainFolder.StorageFolderId;
            }

            var newResource = _resourceMapper.ToEntity(storageResourceDto);
            _unitOfWork.Resources.Add(newResource);
            await _unitOfWork.CompleteAsync();
            return _resourceMapper.ToEntityDTO(newResource);
        }
    }
}