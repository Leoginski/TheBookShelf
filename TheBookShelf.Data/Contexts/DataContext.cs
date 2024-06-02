using Microsoft.EntityFrameworkCore;
using TheBookShelf.Data.Mappings;
using TheBookShelf.Domain.Entities;

namespace TheBookShelf.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new BookMap().Configure(builder.Entity<Book>());
        }

        public DbSet<Book> Books { get; set; }
    }
}
