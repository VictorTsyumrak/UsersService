using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public interface IRepository<TEntity> : IRepositoryContext, IRepositoryAsync<TEntity> where TEntity : class 
    {
        TEntity Get(object id);
        IEnumerable<TEntity> Get();
        TEntity Get(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> predicate);
        void Add(TEntity item);
        void Add(IEnumerable<TEntity> items);
        void Update(TEntity item);
        void Delete(TEntity item);
        IQueryable<TEntity> Items { get; } 
    }
}
