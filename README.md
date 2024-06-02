# TheBookShelf

dotnet ef migrations add InitialMigration -s ../TheBookShelf.Server/TheBookShelf.Api.csproj -v -c DataContext

dotnet ef database update -s /TheBookShelf.Server/TheBookShelf.Api.csproj -v -c DataContext