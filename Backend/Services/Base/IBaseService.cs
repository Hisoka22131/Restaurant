using System.Collections.Generic;
using System.Dynamic;
using Backend.Dto.Base;
using Core.Domain.Base;

namespace Backend.Services.Base;

public interface IBaseService<TEntity, TEntityDto>
    where TEntity : EntityBase
    where TEntityDto : EntityDto
{
    Task<IEnumerable<TEntityDto>> GetEntities();

    Task<TEntityDto> GetEntity(int id);

    void PostEntity(TEntityDto dto);

    void PostDelete(int id);
}