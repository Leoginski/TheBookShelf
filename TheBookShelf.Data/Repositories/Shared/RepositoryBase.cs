using Microsoft.EntityFrameworkCore;
using TheBookShelf.Data.Contexts;
using TheBookShelf.Domain.Entities.Shared;
using TheBookShelf.Domain.Interfaces.Repositories.Shared;

namespace TheBookShelf.Data.Repositories.Shared
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        protected readonly DataContext Context;

        public RepositoryBase(DataContext dataContext) => Context = dataContext;

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await Context.Set<TEntity>().AsNoTracking().ToListAsync();

        public virtual async Task<TEntity?> GetByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

        public virtual async Task<object> InsertAsync(TEntity instance)
        {
            Context.Add(instance);

            await Context.SaveChangesAsync();

            return instance.Id;
        }

        public virtual async Task UpdateAsync(TEntity instance)
        {
            Context.Entry(instance).State = EntityState.Modified;

            await Context.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(TEntity instance)
        {
            Context.Set<TEntity>().Remove(instance);

            await Context.SaveChangesAsync();
        }

        public virtual async Task RemoveByIdAsync(int id)
        {
            var instance = await GetByIdAsync(id);

            if (instance == null)
                throw new Exception("The instance does not exist in the Database.");

            await RemoveAsync(instance);
        }

        public void Dispose() => Context.Dispose();
    }
}
