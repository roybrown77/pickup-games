using System.Collections.Generic;
using System.Transactions;
using PickupGames.Infrastructure.Domain.Models;

namespace PickupGames.Infrastructure.Domain.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<IAggregateRoot, IUnitOfWorkRepository> _addedEntities;
        private readonly Dictionary<IAggregateRoot, IUnitOfWorkRepository> _changedEntities;
        private readonly Dictionary<IAggregateRoot, IUnitOfWorkRepository> _deletedEntities;

        public UnitOfWork()
        {
            _addedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _changedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _deletedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }

        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
           {
            
            if (!_changedEntities.ContainsKey(entity))
            {
                _changedEntities.Add(entity, unitofWorkRepository);
            }
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!_addedEntities.ContainsKey(entity))
            {
                _addedEntities.Add(entity, unitofWorkRepository);
            }
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!_deletedEntities.ContainsKey(entity))
            {
                _deletedEntities.Add(entity, unitofWorkRepository);
            }
        }

        public void Commit()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (IAggregateRoot entity in _addedEntities.Keys)
                {
                    _addedEntities[entity].PersistCreationOf(entity);
                }

                foreach (IAggregateRoot entity in _changedEntities.Keys)
                {
                    _changedEntities[entity].PersistUpdateOf(entity);
                }

                foreach (IAggregateRoot entity in _deletedEntities.Keys)
                {
                    _deletedEntities[entity].PersistDeletionOf(entity);
                }

                scope.Complete();
            }
        }
    }
}