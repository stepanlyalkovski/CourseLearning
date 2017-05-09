using System.Threading.Tasks;
using CourseLearning.Model;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application.Interface
{
    public interface IUserService : IEntityService<UserDTO>
    {
        Task<UserDTO> Get(string email);
    }
}