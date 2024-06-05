using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Book>> SearchAsync(string? author, string? isbn, bool? loved, int pageSize, int pageOffset)
        {
            if (!string.IsNullOrWhiteSpace(author))
                return await SearchByAuthor(author, pageSize, pageOffset);

            if (!string.IsNullOrWhiteSpace(isbn))
                return await SearchByIsbn(isbn, pageSize, pageOffset);

            if (loved is not null)
                return await SearchByLoved(loved.Value, pageSize, pageOffset);

            return await GetAllAsync();
        }

        private async Task<IEnumerable<Book>> SearchByAuthor(string author, int pageSize, int pageOffset)
        {
            string expression = $"%{author}%";

            return await Context.Books
                .OrderBy(x => x.Id)
                .Where(x => EF.Functions.Like(x.FirstName, expression) || EF.Functions.Like(x.LastName, expression))
                .Skip(pageSize * (pageOffset - 1))
                .Take(pageSize)
                .ToListAsync(); ;
        }

        private async Task<IEnumerable<Book>> SearchByIsbn(string isbn, int pageSize, int pageOffset)
        {
            return await Context.Books
                .OrderBy(x => x.Id)
                .Where(x => x.Isbn == isbn)
                .Skip(pageSize * (pageOffset - 1))
                .Take(pageSize)
                .ToListAsync(); ;
        }

        private async Task<IEnumerable<Book>> SearchByLoved(bool loved, int pageSize, int pageOffset)
        {
            return await Context.Books
                .OrderBy(x => x.Id)
                .Where(x => x.Loved == loved)
                .Skip(pageSize * (pageOffset - 1))
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
