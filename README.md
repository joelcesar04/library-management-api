### **API (`library-management-api`)**

# Sistema de Gerenciamento de Biblioteca - API

Esta é a API do Sistema de Gerenciamento de Biblioteca, desenvolvida utilizando **ASP.NET Core** e **SQL Server**. A API oferece serviços para gerenciar livros, autores, categorias e empréstimos.

## Funcionalidades

- API RESTful para gerenciar livros, autores, categorias e empréstimos
- Autenticação e autorização (a ser implementada)
- Conexão com banco de dados SQL Server

## Tecnologias Utilizadas

- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**

## Como Executar o Projeto

### Pré-requisitos

Certifique-se de ter o [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) e o [ASP.NET Core SDK](https://dotnet.microsoft.com/download) instalados.

### Passos para Instalação

1. Clone este repositório:

   ```bash
   git clone https://github.com/joelcesar04/library-management-api.git

2. Navegue até o diretório do projeto:

   ```bash
   cd library-management-api

3. Instale as dependências do projeto:

   ```bash
   dotnet restore

4. Configure o banco de dados SQL Server no arquivo `appsettings.json`:

   ```bash
   "ConnectionStrings": {
      "DefaultConnection": "Server=SEU_SERVIDOR;Database=LibraryDB;Trusted_Connection=True;"
    }

5. Execute as migrations para criar as tabelas no banco de dados:

   ```bash
   dotnet ef database update

## Endpoints Principais

  - `GET /api/livros`: Retorna a lista de livros
  - `POST /api/livros`: Adiciona um novo livro
  - `GET /api/autores`: Retorna a lista de autores
  - `POST /api/autores`: Adiciona um novo autor
  - `GET /api/categorias`: Retorna a lista de categorias

## Contribuições

  Contribuições são bem-vindas! Se você encontrar algum problema ou tiver sugestões, abra uma issue ou envie um pull request.

## Licença

  Este projeto está licenciado sob os termos da [MIT License](LICENSE).
