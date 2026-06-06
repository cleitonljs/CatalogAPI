Criar migration do EF:
	dotnet ef migrations add cria-tabelas-catalogAPI --project .\Infrastructure\Infrastructure.csproj --startup-project .\CatalogAPI\CatalogAPI.csproj

Executar a migration do EF:
	dotnet ef database update --project .\Infrastructure\Infrastructure.csproj --startup-project .\CatalogAPI\CatalogAPI.csproj
	
Para rodar no docker, alterar no appsettings, na string de conexão ao MySql:
	server=host.docker.internal
	
Criar imagem da api para Docker:
	docker build -t catalog-api:1.0 .
	
Executar imagem:
	docker run -p 8081:8080 catalog-api:1.0
	
Abrir a aplicação:
	http://localhost:8081/swagger/index.html