using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;
using ORM;

namespace CourseLearning.DAL
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        protected readonly DbContext Context;

        protected BaseRepository(DbContext context)
        {
            Context = context;
        }

        public virtual async Task<TEntity> FindAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public virtual void Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
