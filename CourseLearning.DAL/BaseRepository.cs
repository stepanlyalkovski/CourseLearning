using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.DAL.Mapper;
using CourseLearning.Model;
using ORM;

namespace CourseLearning.DAL
{
    public abstract class BaseRepository<TDalEntity, TOrmEntity> : IRepository<TDalEntity> where TDalEntity : class where TOrmEntity : DbEntity
    {
        public readonly DbContext Context;
        private TOrmEntity lastAddedEntity;

        protected BaseRepository(DbContext context)
        {
            Context = context;
        }

        public virtual async Task<TDalEntity> Find(int id)
        {
            var ormModel = await Context.Set<TOrmEntity>().FindAsync(id);
            return ToDalModel(ormModel);
        }

        public virtual void Add(TDalEntity entity)
        {
            var ormModel = ToOrmModel(entity);
            Context.Entry(ormModel).State = EntityState.Added;
            lastAddedEntity = ormModel;
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

        public int GetLastId()
        {
            return lastAddedEntity.Id;
        }

        protected virtual TOrmEntity ToOrmModel(TDalEntity dalModel)
        {
            return OrmMapper.Mapper.Map<TDalEntity, TOrmEntity>(dalModel);
        }

        protected virtual TDalEntity ToDalModel(TOrmEntity ormModel)
        {
            return DalMapper.Mapper.Map<TOrmEntity, TDalEntity>(ormModel);
        }
    }
}
