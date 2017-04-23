using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model.ContentStorage;

namespace CourseLearning.DAL
{
    public class StorageFolderRepository : BaseRepository<StorageFolder>, IStorageFolderRepository
    {
        public StorageFolderRepository(DbContext context) : base(context)
        {
        }

        public async Task<IList<StorageFolder>> GetStorageFoldersAsync(int storageId)
        {
            var folder = await Context.Set<UserStorage>()
                .Include(s => s.StorageFolders)
                .FirstOrDefaultAsync(s => s.UserStorageId == storageId);
            return folder.StorageFolders;
        }

        public async Task<StorageFolder> FindAsync(int storageFolderId, bool includeFolderContent)
        {
            if (!includeFolderContent)
            {
                return await FindAsync(storageFolderId);
            }

            return await Context.Set<StorageFolder>()
                .Include(f => f.Resources)
                .FirstOrDefaultAsync(f => f.StorageFolderId == storageFolderId);
        }

        public async Task<StorageFolder> GetMainFolderAsync(int userId)
        {
            return await Context.Set<StorageFolder>().FirstOrDefaultAsync(f => f.UserStorageId == userId && f.IsDefaultFolder);
        }
    }
}