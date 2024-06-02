using TheBookShelf.Domain.Entities.Shared;
using TheBookShelf.Domain.Interfaces.Repositories.Shared;
using TheBookShelf.Domain.Interfaces.Services.Shared;

namespace TheBookShelf.Domain.Services.Shared
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : Entity
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase) => _repositoryBase = repositoryBase;

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _repositoryBase.GetAllAsync();

        public virtual async Task<TEntity?> GetByIdAsync(int id) => await _repositoryBase.GetByIdAsync(id);

        public virtual async Task<object> AddAsync(TEntity instance) => await _repositoryBase.InsertAsync(instance);

        public virtual async Task UpdateAsync(TEntity instance) => await _repositoryBase.UpdateAsync(instance);

        public virtual async Task DeleteAsync(TEntity instance) => await _repositoryBase.RemoveAsync(instance);

        public virtual async Task DeleteByIdAsync(int id) => await _repositoryBase.RemoveByIdAsync(id);

        public void Dispose() => _repositoryBase.Dispose();
    }
}
