using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheBookShelf.Domain.Entities;

namespace TheBookShelf.Data.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(100).IsRequired(true);
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.TotalCopies).IsRequired(true).HasDefaultValue(0);
            builder.Property(p => p.CopiesInUse).IsRequired(true).HasDefaultValue(0);
            builder.Property(p => p.Type).HasMaxLength(50);
            builder.Property(p => p.Isbn).HasMaxLength(80);
            builder.Property(p => p.Category).HasMaxLength(50);

            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "Pride and Prejudice",
                    FirstName = "Jane",
                    LastName = "Austen",
                    TotalCopies = 100,
                    CopiesInUse = 80,
                    Type = "Hardcover",
                    Isbn = "1234567891",
                    Category = "Fiction"
                },
                new Book
                {
                    Id = 2,
                    Title = "To Kill a Mockingbird",
                    FirstName = "Harper",
                    LastName = "Lee",
                    TotalCopies = 75,
                    CopiesInUse = 65,
                    Type = "Paperback",
                    Isbn = "1234567892",
                    Category = "Fiction"
                },
                new Book
                {
                    Id = 3,
                    Title = "The Catcher in the Rye",
                    FirstName = "J.D.",
                    LastName = "Salinger",
                    TotalCopies = 50,
                    CopiesInUse = 45,
                    Type = "Hardcover",
                    Isbn = "1234567893",
                    Category = "Fiction"
                },
                new Book
                {
                    Id = 4,
                    Title = "The Great Gatsby",
                    FirstName = "F. Scott",
                    LastName = "Fitzgerald",
                    TotalCopies = 50,
                    CopiesInUse = 22,
                    Type = "Hardcover",
                    Isbn = "1234567894",
                    Category = "Non-Fiction"
                },
                new Book
                {
                    Id = 5,
                    Title = "The Alchemist",
                    FirstName = "Paulo",
                    LastName = "Coelho",
                    TotalCopies = 50,
                    CopiesInUse = 35,
                    Type = "Hardcover",
                    Isbn = "1234567895",
                    Category = "Biography"
                },
                new Book
                {
                    Id = 6,
                    Title = "The Alchemist",
                    FirstName = "Paulo",
                    LastName = "Coelho",
                    TotalCopies = 50,
                    CopiesInUse = 35,
                    Type = "Hardcover",
                    Isbn = "1234567895",
                    Category = "Biography"
                },
                new Book
                {
                    Id = 7,
                    Title = "The Book Thief",
                    FirstName = "Markus",
                    LastName = "Zusak",
                    TotalCopies = 75,
                    CopiesInUse = 11,
                    Type = "Hardcover",
                    Isbn = "1234567896",
                    Category = "Mystery"
                },
                new Book
                {
                    Id = 8,
                    Title = "The Chronicles of Narnia",
                    FirstName = "C.S.",
                    LastName = "Lewis",
                    TotalCopies = 100,
                    CopiesInUse = 14,
                    Type = "Paperback",
                    Isbn = "1234567897",
                    Category = "Sci-Fi"
                },
                new Book
                {
                    Id = 9,
                    Title = "The Da Vinci Code",
                    FirstName = "Dan",
                    LastName = "Brown",
                    TotalCopies = 50,
                    CopiesInUse = 40,
                    Type = "Paperback",
                    Isbn = "1234567898",
                    Category = "Sci-Fi"
                },
                new Book
                {
                    Id = 10,
                    Title = "The Grapes of Wrath",
                    FirstName = "John",
                    LastName = "Steinbeck",
                    TotalCopies = 50,
                    CopiesInUse = 35,
                    Type = "Hardcover",
                    Isbn = "1234567899",
                    Category = "Fiction"
                },
                new Book
                {
                    Id = 11,
                    Title = "The Hitchhiker\"\"s Guide to the Galaxy",
                    FirstName = "Douglas",
                    LastName = "Adams",
                    TotalCopies = 50,
                    CopiesInUse = 35,
                    Type = "Paperback",
                    Isbn = "1234567900",
                    Category = "Non-Fiction"
                },
                new Book
                {
                    Id = 12,
                    Title = "Moby-Dick",
                    FirstName = "Herman",
                    LastName = "Melville",
                    TotalCopies = 30,
                    CopiesInUse = 8,
                    Type = "Hardcover",
                    Isbn = "8901234567",
                    Category = "Fiction"
                },
                new Book
                {
                    Id = 13,
                    Title = "To Kill a Mockingbird",
                    FirstName = "Harper",
                    LastName = "Lee",
                    TotalCopies = 20,
                    CopiesInUse = 0,
                    Type = "Paperback",
                    Isbn = "9012345678",
                    Category = "Non-Fiction"
                },
                new Book
                {
                    Id = 14,
                    Title = "The Catcher in the Rye",
                    FirstName = "J.D.",
                    LastName = "Salinger",
                    TotalCopies = 10,
                    CopiesInUse = 1,
                    Type = "Hardcover",
                    Isbn = "0123456789",
                    Category = "Non-Fiction"
                });
        }
    }
}
