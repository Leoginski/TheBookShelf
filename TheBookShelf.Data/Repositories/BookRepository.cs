using TheBookShelf.Data.Contexts;
using TheBookShelf.Data.Repositories.Shared;
using TheBookShelf.Domain.Entities;
using TheBookShelf.Domain.Interfaces.Repositories;

namespace TheBookShelf.Data.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
