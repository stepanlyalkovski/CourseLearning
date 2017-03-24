using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;
using CourseLearning.Model.Mapper;

namespace CourseLearning.DAL
{
    public abstract class BaseRepository<TDalEntity, TOrmEntity> where TOrmEntity : class, IRepository<TDalEntity> where TDalEntity : BaseEntity
    {
        protected readonly DbContext Context;

        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        public virtual TDalEntity Find(int id)
        {
            throw new NotImplementedException();
          // return Context.Set<TOrmEntity>().Find(id);
        }

        public virtual void Add(TDalEntity entity)
        {
            var ormModel = ToOrmModel(entity);
            Context.Entry(ormModel).State = EntityState.Added;
        }

        public virtual void Update(TDalEntity entity)
        {
            var ormModel = ToOrmModel(entity);
            Context.Entry(ormModel).State = EntityState.Modified;
        }

        public virtual void Delete(TDalEntity entity)
        {
            var ormModel = ToOrmModel(entity);
            Context.Entry(ormModel).State = EntityState.Deleted;
        }

        protected TOrmEntity ToOrmModel(TDalEntity dalModel)
        {
            return OrmMapper.Mapper.Map<TDalEntity, TOrmEntity>(dalModel);
        }
    }
}
