# TheBookShelf

dotnet ef migrations add InitialMigration -s ../TheBookShelf.Server/TheBookShelf.Api.csproj -v -c DataContext

dotnet ef database update -s /TheBookShelf.Server/TheBookShelf.Api.csproj -v -c DataContext

docker build -t leoginski/thebookshelfapi:1.0.0 -f TheBookShelf.Server/Dockerfile .

docker push leoginski/thebookshelfapi:1.0.0

az login

az ad sp create-for-rbac --skip-assignment

Copy the resulting object, example:
{
  "appId": "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa",
  "displayName": "azure-cli-2019-04-11-00-46-05",
  "name": "http://azure-cli-2019-04-11-00-46-05",
  "password": "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa",
  "tenant": "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"
}

Update your terraform.tfvars file with appId and Password

