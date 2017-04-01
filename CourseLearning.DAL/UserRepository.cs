using System.Data.Entity;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;

namespace CourseLearning.DAL
{
    public class UserRepository : BaseRepository<User, ORM.User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public async Task<User> GetAsync(string name)
        {
            var ormUser = await Context.Set<ORM.User>().FirstOrDefaultAsync(u => u.Name == name);
            return ToDalModel(ormUser);
        }

    }
}