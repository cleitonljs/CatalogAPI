Criar migration do EF:
	dotnet ef migrations add cria-tabelas-catalogAPI --project .\Infrastructure\Infrastructure.csproj --startup-project .\CatalogAPI\CatalogAPI.csproj

Executar a migration do EF:
	dotnet ef database update --project .\Infrastructure\Infrastructure.csproj --startup-project .\CatalogAPI\CatalogAPI.csproj