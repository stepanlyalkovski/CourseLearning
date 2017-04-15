using System.Collections.Generic;
using System.Linq;

namespace CourseLearning.Application.Mapper
{
    public class DtoMapper<TEntity, TEntityDTO>
    {
        public TEntity ToEntity(TEntityDTO dtoModel)
        {
            return DtoMapperConfiguration.Mapper.Map<TEntityDTO, TEntity>(dtoModel);
        }

        public IList<TEntity> ToEntities(IList<TEntityDTO> dtoModels)
        {
            return dtoModels.Select(ToEntity).ToList();
        }

        public TEntityDTO ToEntityDTO(TEntity entityModel)
        {
            return DtoMapperConfiguration.Mapper.Map<TEntity, TEntityDTO>(entityModel);
        }

        public IList<TEntityDTO> ToEntitiesDTO(IList<TEntity> entityModels)
        {
            return entityModels.Select(ToEntityDTO).ToList();
        }
    }
}