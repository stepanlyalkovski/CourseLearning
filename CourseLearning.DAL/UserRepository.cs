using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;

namespace CourseLearning.DAL
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public async Task<User> GetAsync(string email)
        {
            return await Context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }

        public override async Task<User> FindAsync(int id)
        {
            return await Context.Set<User>().Include(u => u.UserStorage).FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}