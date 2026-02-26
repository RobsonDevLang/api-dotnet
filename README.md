## fundamentosApi

API REST simples em ASP.NET Core para gerenciamento de contatos de uma agenda, construída com Entity Framework Core e SQL Server.

### Visão geral

Esta API expõe endpoints para:
- **Listar contatos**
- **Buscar contato por id**
- **Buscar contatos por nome**
- **Criar, atualizar (PUT/PATCH) e remover contatos**

Ela utiliza um `DbContext` (`AgendaContext`) com a entidade `Contatos` persistida em um banco SQL Server.

### Tecnologias usadas

- **.NET**: `net10.0`
- **ASP.NET Core Web API**
- **Entity Framework Core** (`SqlServer`, `Design`)
- **OpenAPI/Swagger** (via `Microsoft.AspNetCore.OpenApi`)

### Pré‑requisitos

- **.NET SDK 10.0** ou superior instalado
- **SQL Server** acessível (local ou remoto)
- Acesso para ajustar a `ConnectionString` no `appsettings.json`

### Configuração

1. **Clone o repositório**

```bash
git clone <url-do-repositorio>
cd fundamentosApi
```

2. **Configurar a string de conexão**

No arquivo `appsettings.json`, ajuste a connection string `ConexaoPadrao` para apontar para o seu SQL Server:

```json
{
  "ConnectionStrings": {
    "ConexaoPadrao": "Server=SEU_SERVIDOR;Database=AgendaDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

3. **Aplicar migrações (opcional, se ainda não houver banco criado)**

Se tiver o `dotnet-ef` instalado:

```bash
dotnet ef database update
```

Caso contrário, instale a ferramenta:

```bash
dotnet tool install --global dotnet-ef
```

e depois execute novamente:

```bash
dotnet ef database update
```

### Executando o projeto

Na raiz do projeto, execute:

```bash
dotnet run
```

Por padrão, a API sobe em HTTPS (porta configurada no `launchSettings.json`). Em ambiente de **Development**, o endpoint de documentação OpenAPI/Swagger também é exposto.

### Endpoints principais

Controller: `ContatosController` (`/Contatos`)

- **GET `/Contatos`**  
  Retorna todos os contatos.

- **GET `/Contatos/{id}`**  
  Retorna um contato específico pelo `id`.

- **GET `/Contatos/SelecionarPorNome/{nome}`**  
  Retorna contatos cujo nome contenha o valor informado em `{nome}`.

- **POST `/Contatos`**  
  Cria um novo contato.

- **PUT `/Contatos/{id}`**  
  Atualiza completamente os dados de um contato existente.

- **PATCH `/Contatos/{id}`**  
  Atualização parcial dos dados de um contato (somente propriedades enviadas).

- **DELETE `/Contatos/{id}`**  
  Remove um contato.


  Controller: `ClientesController` (`/Clientes`)

- **GET `/Clientes`**  
  Retorna todos os Clientes.

- **GET `/Clientes/{id}`**  
  Retorna um contato específico pelo `id`.

- **GET `/Clientes/SelecionarPorNome/{nome}`**  
  Retorna contatos cujo nome contenha o valor informado em `{nome}`.

- **POST `/Clientes`**  
  Cria um novo contato.

- **PUT `/Clientes/{id}`**  
  Atualiza completamente os dados de um contato existente.

- **PATCH `/Clientes/{id}`**  
  Atualização parcial dos dados de um contato (somente propriedades enviadas).

- **DELETE `/Clientes/{id}`**  
  Remove um contato.

### Estrutura básica do projeto

- `Program.cs` – configuração da aplicação, DI do `AgendaContext`, mapeamento de controllers e OpenAPI.
- `Context/AgendaContext.cs` – contexto do Entity Framework Core.
- `Entities/Contatos.cs` – entidade de contatos.
- `Controllers/ContatosController.cs` – endpoints da API de contatos.
- `Migrations/` – migrações do banco de dados.

### Contribuindo

- **Fork** o projeto
- Crie um branch de feature: `git checkout -b minha-feature`
- Faça commits claros e objetivos
- Abra um Pull Request descrevendo as mudanças

