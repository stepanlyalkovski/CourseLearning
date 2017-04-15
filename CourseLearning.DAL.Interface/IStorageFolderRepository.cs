using System.Collections.Generic;
using System.Threading.Tasks;
using CourseLearning.Model.ContentStorage;

namespace CourseLearning.DAL.Interface
{
    public interface IStorageFolderRepository : IRepository<StorageFolder>
    {
        Task<IList<StorageFolder>> GetStorageFoldersAsync(int storageId);

        Task<StorageFolder> FindAsync(int storageFolderId, bool includeFolderContent);
    }
}