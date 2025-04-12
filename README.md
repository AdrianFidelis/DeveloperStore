# DeveloperStore API

API RESTful para registro de vendas, desenvolvida com arquitetura em camadas (DDD) e Entity Framework Core, atendendo ao desafio de avaliação da NTT Data.

## Tecnologias Utilizadas

- .NET 8.0.408 (LTS)
- ASP.NET Core Web API
- Entity Framework Core 8.0.4
- SQL Server
- xUnit (testes)
- Swagger

## Como Executar

### 1. Clonar o repositório
```bash
git clone https://github.com/seu-usuario/DeveloperStore.git
cd DeveloperStore
```

### 2. Configurar o Banco de Dados
Verifique ou ajuste a string de conexão no arquivo `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=DeveloperStoreDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

### 3. Aplicar as Migrations
```bash
dotnet ef database update -p DeveloperStore.Infrastructure -s DeveloperStore.API
```

### 4. Executar o Projeto
```bash
dotnet run --project DeveloperStore.API
```
Acesse em: [https://localhost:port/swagger](https://localhost:port/swagger)

## Endpoints Principais

| Método | Rota                              | Ação                    |
|--------|-----------------------------------|----------------------------|
| POST   | `/api/sales`                     | Cria uma nova venda       |
| GET    | `/api/sales`                     | Lista todas as vendas     |
| GET    | `/api/sales/{id}`                | Busca venda por ID        |
| PUT    | `/api/sales/{id}/edit`           | Edita cliente e filial    |
| PUT    | `/api/sales/{id}/cancel`         | Cancela a venda           |
| PUT    | `/api/sales/{saleId}/items/{id}/cancel` | Cancela item da venda |

## Regras de Negócio

- 4 a 9 unidades: **10% de desconto**
- 10 a 20 unidades: **20% de desconto**
- Mais de 20 unidades: **não permitido**
- Menos de 4: **sem desconto**

## Testes

### Executar todos os testes
```bash
dotnet test DeveloperStore.Tests
```

- `SaleTests.cs`: testa regras de negócio e entidades
- `SalesControllerTests.cs`: testa a API com InMemoryDatabase

---

Desenvolvido por **Adrian Soares Fidelis**

> Desafio técnico para vaga .NET da NTT Data
