using System.Threading.Tasks;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application.Interface
{
    public interface IResourceService : IEntityService<StorageResourceDTO>
    {
        Task<StorageResourceDTO> AddResource(StorageResourceDTO storageResourceDto);
    }
}