using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Domain.Base;

namespace Contracts.DAL.Base.Repositories
{
    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, Guid>
        where TEntity : class, IDomainEntityId // any more rules? mb ID?
    {
        
    }

    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class, IDomainEntityId<TKey> // any more rules? mb ID?
        where TKey: IEquatable<TKey> //id.equals(someotherid)
    {
        //crud
    // list of tentity
    Task<IEnumerable<TEntity>> GetAllAsync(bool noTracking = true);
    //single tentity
    Task<TEntity> FirstOrDefaultAsync(TKey id,bool noTracking = true);
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Remove(TEntity entity);
    Task<TEntity> Remove(TKey id);
    Task<bool> ExistsAsync(TKey id);
    }

}