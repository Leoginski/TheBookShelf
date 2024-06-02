using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheBookShelf.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalCopies = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CopiesInUse = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Category", "CopiesInUse", "FirstName", "Isbn", "LastName", "Title", "TotalCopies", "Type" },
                values: new object[,]
                {
                    { 1, "Fiction", 80, "Jane", "1234567891", "Austen", "Pride and Prejudice", 100, "Hardcover" },
                    { 2, "Fiction", 65, "Harper", "1234567892", "Lee", "To Kill a Mockingbird", 75, "Paperback" },
                    { 3, "Fiction", 45, "J.D.", "1234567893", "Salinger", "The Catcher in the Rye", 50, "Hardcover" },
                    { 4, "Non-Fiction", 22, "F. Scott", "1234567894", "Fitzgerald", "The Great Gatsby", 50, "Hardcover" },
                    { 5, "Biography", 35, "Paulo", "1234567895", "Coelho", "The Alchemist", 50, "Hardcover" },
                    { 6, "Biography", 35, "Paulo", "1234567895", "Coelho", "The Alchemist", 50, "Hardcover" },
                    { 7, "Mystery", 11, "Markus", "1234567896", "Zusak", "The Book Thief", 75, "Hardcover" },
                    { 8, "Sci-Fi", 14, "C.S.", "1234567897", "Lewis", "The Chronicles of Narnia", 100, "Paperback" },
                    { 9, "Sci-Fi", 40, "Dan", "1234567898", "Brown", "The Da Vinci Code", 50, "Paperback" },
                    { 10, "Fiction", 35, "John", "1234567899", "Steinbeck", "The Grapes of Wrath", 50, "Hardcover" },
                    { 11, "Non-Fiction", 35, "Douglas", "1234567900", "Adams", "The Hitchhiker\"\"s Guide to the Galaxy", 50, "Paperback" },
                    { 12, "Fiction", 8, "Herman", "8901234567", "Melville", "Moby-Dick", 30, "Hardcover" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Category", "FirstName", "Isbn", "LastName", "Title", "TotalCopies", "Type" },
                values: new object[] { 13, "Non-Fiction", "Harper", "9012345678", "Lee", "To Kill a Mockingbird", 20, "Paperback" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Category", "CopiesInUse", "FirstName", "Isbn", "LastName", "Title", "TotalCopies", "Type" },
                values: new object[] { 14, "Non-Fiction", 1, "J.D.", "0123456789", "Salinger", "The Catcher in the Rye", 10, "Hardcover" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
