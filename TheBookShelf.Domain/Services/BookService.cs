using TheBookShelf.Domain.Entities;
using TheBookShelf.Domain.Interfaces.Repositories;
using TheBookShelf.Domain.Interfaces.Services;
using TheBookShelf.Domain.Services.Shared;

namespace TheBookShelf.Domain.Services
{
    public class BookService : ServiceBase<Book>, IBookService
    {
        public BookService(IBookRepository repository) : base(repository)
        {
        }
    }
}
