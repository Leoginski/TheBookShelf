using TheBookShelf.Domain.Entities;

namespace TheBookShelf.Application.DTOs.Responses
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }
        public string Type { get; set; }
        public string Isbn { get; set; }
        public string Category { get; set; }
        public bool Loved { get; set; }

        public BookResponse()
        {
        }

        public static BookResponse ToResponse(Book entity)
        {
            return new BookResponse
            {
                Id = entity.Id,
                Title = entity.Title,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                TotalCopies = entity.TotalCopies,
                CopiesInUse = entity.CopiesInUse,
                Type = entity.Type,
                Isbn = entity.Isbn,
                Category = entity.Category,
                Loved = entity.Loved,
            };
        }
    }
}
