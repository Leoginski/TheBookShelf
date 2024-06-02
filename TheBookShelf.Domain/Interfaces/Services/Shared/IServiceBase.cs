using TheBookShelf.Domain.Entities.Shared;

namespace TheBookShelf.Domain.Interfaces.Services.Shared
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<object> AddAsync(TEntity instance);
        Task UpdateAsync(TEntity instance);
        Task DeleteAsync(TEntity instance);
        Task DeleteByIdAsync(int id);
    }
}
