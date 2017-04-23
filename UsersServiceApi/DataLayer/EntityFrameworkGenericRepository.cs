using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EntityFrameworkGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        public DbContext Context { get; set; }
        private DbSet<TEntity> DbSet { get; }

        public EntityFrameworkGenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Items => DbSet.AsQueryable();
        public int ContextHashCode => Context.GetHashCode();

        public TEntity Get(object id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return DbSet.AsEnumerable();
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            return DbSet.Where(predicate).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetMany(Func<TEntity, bool> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Add(TEntity item)
        {
            DbSet.Add(item);
        }

        public void Add(IEnumerable<TEntity> items)
        {
            DbSet.AddRange(items);
        }

        public void Update(TEntity item)
        {
            DbSet.Attach(item);
            Context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(TEntity item)
        {
            if (Context.Entry(item).State == EntityState.Detached)
            {
                DbSet.Attach(item);
            }

            DbSet.Remove(item);
        }

        public Task<TEntity> GetAsync(object id)
        {
            return DbSet.FindAsync(id);
        }

        public Task<List<TEntity>> GetAsync()
        {
            return DbSet.ToListAsync();
        }

        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }

        public virtual Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
