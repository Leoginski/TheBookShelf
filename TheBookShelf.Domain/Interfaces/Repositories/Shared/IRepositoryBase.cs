using TheBookShelf.Domain.Entities;
using TheBookShelf.Domain.Entities.Shared;

namespace TheBookShelf.Domain.Interfaces.Repositories.Shared
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<object> InsertAsync(TEntity instance);
        Task UpdateAsync(TEntity instance);
        Task RemoveAsync(TEntity instance);
        Task RemoveByIdAsync(int id);
    }
}
