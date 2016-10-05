using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SchoolBus.DataAccess.Entities;

namespace SchoolBus.DataAccess.Repositories
{
    public interface IEntityRepository<TEntity> : IDisposable
        where TEntity : class, IEntity
    {
        #region Methods

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);

        TEntity Add(TEntity entity, int creatorId);

        TEntity Update(TEntity entity, int updaterId);

        TEntity Deactivate(TEntity entity, int deactivatorId);

        #endregion Methods
    }
}