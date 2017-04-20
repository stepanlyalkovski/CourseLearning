using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseLearning.Model;

namespace CourseLearning.DAL.Interface
{
    public interface IRepository<TEntity>  where TEntity : class
    {
        Task<TEntity> FindAsync(int id);

        void Add(TEntity entity);

        Task Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
