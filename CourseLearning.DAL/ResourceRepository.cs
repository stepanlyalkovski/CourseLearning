using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model.ContentStorage;

namespace CourseLearning.DAL
{
    public class ResourceRepository : BaseRepository<StorageResource>, IResourceRepository
    {
        public ResourceRepository(DbContext context) : base(context)
        {
        }

        public async Task<IList<StorageResource>> GetStorageFolderResources(int folderId)
        {
            return await Context.Set<StorageResource>().Where(r => r.StorageFolderId == folderId).ToListAsync();
        }
    }
}