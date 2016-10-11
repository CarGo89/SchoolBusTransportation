using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dpr.Core.DataAccess;
using SchoolBus.DataAccess.Entities;

namespace SchoolBus.DataAccess.Repositories
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity
    {
        #region Fields

        private readonly IRepository<TEntity> _repository;

        private bool _disposed;

        #endregion Fields

        #region Constructors

        public EntityRepository()
            : this(FactoryRepository.Create<SchoolBusDataModel, TEntity>())
        {
        }

        public EntityRepository(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        #endregion Constructors

        #region Private Methods

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _repository.Dispose();
            }

            _disposed = true;
        }

        #endregion Private Methods

        #region Public Methods

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _repository.GetAll() : _repository.GetAll(filter);
        }

        public TEntity Add(TEntity entity, int creatorId)
        {
            var now = DateTime.Now;

            entity.CreatedBy = null;
            entity.CreatedById = creatorId;
            entity.CreatedAt = now;

            entity.UpdatedBy = null;
            entity.UpdatedById = creatorId;
            entity.UpdatedAt = now;

            entity.DeactivatedBy = null;
            entity.DeactivatedById = null;
            entity.DeactivatedAt = null;

            return _repository.Add(entity);
        }

        public TEntity Update(TEntity entity, int updaterId)
        {
            var entityToUpdate = _repository.Single(savedEntity => savedEntity.Id == entity.Id);

            if (entityToUpdate == null)
            {
                return entity;
            }

            entity.UpdatedBy = null;
            entity.UpdatedById = updaterId;
            entity.UpdatedAt = DateTime.Now;

            entity.CreatedBy = null;
            entity.CreatedById = entityToUpdate.CreatedById;
            entity.CreatedAt = entityToUpdate.CreatedAt;

            entity.DeactivatedBy = null;
            entity.DeactivatedById = entityToUpdate.DeactivatedById;
            entity.DeactivatedAt = entityToUpdate.DeactivatedAt;

            return _repository.Update(entity);
        }

        public TEntity Deactivate(TEntity entity, int deactivatorId)
        {
            var entityToDeactivate = _repository.Single(savedEntity => savedEntity.Id == entity.Id);

            if (entityToDeactivate == null)
            {
                return entity;
            }

            var now = DateTime.Now;

            entity.DeactivatedBy = null;
            entity.DeactivatedById = deactivatorId;
            entity.DeactivatedAt = now;

            entity.UpdatedBy = null;
            entity.UpdatedById = deactivatorId;
            entity.UpdatedAt = now;

            entity.CreatedBy = null;
            entity.CreatedById = entityToDeactivate.CreatedById;
            entity.CreatedAt = entityToDeactivate.CreatedAt;

            return _repository.Update(entity);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion Public Methods
    }
}