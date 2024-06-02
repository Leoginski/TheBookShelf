using TheBookShelf.Domain.Entities;

namespace TheBookShelf.Application.DTOs.Requests
{
    public class UpdateBookRequest
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

        public UpdateBookRequest()
        {
        }

        public static Book ToEntity(UpdateBookRequest request)
        {
            return new Book
            {
                Id = request.Id,
                Title = request.Title,
                FirstName = request.FirstName,
                LastName = request.LastName,
                TotalCopies = request.TotalCopies,
                CopiesInUse = request.CopiesInUse,
                Type = request.Type,
                Isbn = request.Isbn,
                Category = request.Category
            };
        }
    }
}
