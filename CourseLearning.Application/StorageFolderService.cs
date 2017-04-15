using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Application.Interface;
using CourseLearning.DAL.Interface;
using CourseLearning.Model.ContentStorage;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application
{
    public class StorageFolderService : BaseEntityService<StorageFolder,StorageFolderDTO>, IStorageFolderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StorageFolderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(StorageFolderDTO storageFolderDTO)
        {
            var storageFolder = ToEntity(storageFolderDTO);
            //check user
            var userStorage = await _unitOfWork.Users.FindAsync(storageFolder.UserStorageId);
            if (userStorage?.UserStorage == null)
            {
                throw new ArgumentException("Current user or user storage doesn't exist", nameof(storageFolderDTO.UserStorageId));
            }

            _unitOfWork.StorageFolders.Add(storageFolder);
            await _unitOfWork.CompleteAsync();
            return storageFolder.StorageFolderId;
        }

        public async Task<StorageFolderDTO> Get(int id)
        {
            return await Get(id, false);
        }

        public async Task<StorageFolderDTO> Get(int id, bool includeContent)
        {
            var storageFolder = await _unitOfWork.StorageFolders.FindAsync(id, includeContent);
            return ToEntityDTO(storageFolder);
        }

        public Task Delete(StorageFolderDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(StorageFolderDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<StorageFolderDTO>> GetStorageFoldersAsync(int storageId)
        {
            var foldes = await _unitOfWork.StorageFolders.GetStorageFoldersAsync(storageId);
            return ToEntitiesDTO(foldes);
        }
    }
}