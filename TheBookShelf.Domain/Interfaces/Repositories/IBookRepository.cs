using TheBookShelf.Domain.Entities;
using TheBookShelf.Domain.Interfaces.Repositories.Shared;

namespace TheBookShelf.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
    }
}
