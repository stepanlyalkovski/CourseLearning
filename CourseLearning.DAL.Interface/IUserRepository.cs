using System.Threading.Tasks;
using CourseLearning.Model;

namespace CourseLearning.DAL.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetAsync(string name);
    }
}