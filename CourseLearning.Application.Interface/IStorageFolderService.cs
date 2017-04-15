using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model.ContentStorage;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application.Interface
{
    public interface IStorageFolderService : IEntityService<StorageFolderDTO>
    {
        Task<IList<StorageFolderDTO>> GetStorageFoldersAsync(int storageId);

        Task<StorageFolderDTO> Get(int id, bool includeContent = false);
    }
}