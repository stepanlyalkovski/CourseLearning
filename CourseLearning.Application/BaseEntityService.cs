using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLearning.Application.Interface;
using CourseLearning.Application.Mapper;
using CourseLearning.DAL.Interface;

namespace CourseLearning.Application
{
    public abstract class BaseEntityService<TEntity, TEntityDTO>
    {
        public virtual TEntity ToEntity(TEntityDTO dtoModel)
        {
            return DtoMapperConfiguration.Mapper.Map<TEntityDTO, TEntity>(dtoModel);
        }

        public virtual IList<TEntity> ToEntities(IList<TEntityDTO> dtoModels)
        {
            return dtoModels.Select(ToEntity).ToList();
        }

        public virtual TEntityDTO ToEntityDTO(TEntity entityModel)
        {
            return DtoMapperConfiguration.Mapper.Map<TEntity, TEntityDTO>(entityModel);
        }

        public virtual IList<TEntityDTO> ToEntitiesDTO(IList<TEntity> entityModels)
        {
            return entityModels.Select(ToEntityDTO).ToList();
        }
    }
}