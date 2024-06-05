using TheBookShelf.Domain.Entities;
using TheBookShelf.Domain.Interfaces.Services.Shared;

namespace TheBookShelf.Domain.Interfaces.Services
{
    public interface IBookService : IServiceBase<Book>
    {
        Task<IEnumerable<Book>> SearchAsync(string? author, string? isbn, bool? loved, int pageSize, int pageOffset);
    }
}
