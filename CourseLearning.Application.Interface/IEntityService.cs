using System.Threading.Tasks;

namespace CourseLearning.Application.Interface
{
    public interface IEntityService<TEntity>
    {
        Task<int> Add(TEntity entity);

        Task<TEntity> Get(int id);

        Task Delete(TEntity entity);

        Task Update(TEntity entity);
    }
}