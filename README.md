# Clean Architecture - .NET Project

Este projeto utiliza Clean Architecture com .NET, PostgreSQL e Entity Framework Core.

## 📋 Pré-requisitos

- .NET 10.0 SDK
- PostgreSQL
- Visual Studio Code ou Visual Studio

## 🔧 Configuração

### 1. Clone o repositório

```bash
git clone <seu-repositorio>
cd CleanArchitecture
```

### 2. Configure as variáveis de ambiente

Copie o arquivo `.env.example` para `.env`:

```bash
cp .env.example .env
```

Edite o arquivo `.env` com suas credenciais do banco de dados:

```env
DB_HOST=localhost
DB_NAME=CleanArchitectureDb
DB_USER=postgres
DB_PASSWORD=sua_senha_aqui
DB_PORT=5432
```

### 3. Instale as dependências

```bash
dotnet restore
```

### 4. Execute as migrations

As migrations serão aplicadas automaticamente ao executar o projeto, mas você pode aplicá-las manualmente com:

```bash
cd Presentation
dotnet ef database update --project ../Infrastructure
```

### 5. Execute o projeto

```bash
cd Presentation
dotnet run
```

O projeto estará disponível em:
- HTTP: http://localhost:5000
- HTTPS: https://localhost:5001
- Swagger: https://localhost:5001/swagger

## 🏗️ Estrutura do Projeto

```
CleanArchitecture/
├── Domain/          # Entidades e interfaces
├── Application/     # CQRS, DTOs e lógica de negócio
├── Infrastructure/  # DbContext, Repositories e Migrations
├── CrossCutting/    # Injeção de dependência
└── Presentation/    # API Controllers e configuração
```

## 🔒 Segurança

**IMPORTANTE:** Nunca commite o arquivo `.env` no repositório. Este arquivo contém informações sensíveis e já está incluído no `.gitignore`.

O arquivo `.env.example` é apenas um template e deve ser usado como referência.

## 📚 Tecnologias

- **.NET 10.0**
- **Entity Framework Core**
- **PostgreSQL**
- **MediatR** (CQRS)
- **Swagger/OpenAPI**

## 🚀 Deploy

Ao fazer deploy em produção, configure as variáveis de ambiente no seu servidor/plataforma de hospedagem ao invés de usar o arquivo `.env`.

## 📝 License

Este projeto está sob a licença MIT.
