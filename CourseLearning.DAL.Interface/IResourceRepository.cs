using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using CourseLearning.Model.ContentStorage;

namespace CourseLearning.DAL.Interface
{
    public interface IResourceRepository : IRepository<StorageResource>
    {
        Task<IList<StorageResource>> GetStorageFolderResources(int folderId);
    }
}