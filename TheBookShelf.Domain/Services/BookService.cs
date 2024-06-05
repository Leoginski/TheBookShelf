using TheBookShelf.Domain.Entities;
using TheBookShelf.Domain.Interfaces.Repositories;
using TheBookShelf.Domain.Interfaces.Services;
using TheBookShelf.Domain.Services.Shared;

namespace TheBookShelf.Domain.Services
{
    public class BookService : ServiceBase<Book>, IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Book>> SearchAsync(string? author, string? isbn, bool? loved, int pageSize, int pageOffset)
        {
            return await _repository.SearchAsync(author, isbn, loved, pageSize, pageOffset);
        }
    }
}
