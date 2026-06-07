# AdminSiste

Administrador de site desenvolvido em ASP.NET Core Razor Pages com MySQL e Entity Framework Core.

## Visão geral

O projeto `AdminSiste` é uma aplicação administrativa para gerenciamento de clientes, produtos e serviços. Inclui autenticação por cookie, CRUD para entidades principais e um painel de navegação com páginas de listagem e cadastro.

## Funcionalidades

- Autenticação de usuário com cookies
- Página de login e logout
- Dashboard administrativo
- Cadastro e edição de clientes
- Listagem de clientes
- Cadastro e edição de produtos
- Listagem de produtos
- Cadastro e edição de serviços
- Listagem de serviços
- Estrutura Razor Pages com controllers e serviços

## Arquitetura

- `Program.cs` - configuração do pipeline ASP.NET Core, serviços e autenticação
- `Data/AppDbContext.cs` - contexto do Entity Framework Core
- `Controllers/` - controllers para endpoints adicionais
- `Pages/` - páginas Razor para UI e fluxos de navegação
- `Services/` - lógica de serviço e regras de negócio
- `Models/` - entidades de domínio e view models

## Pré-requisitos

- .NET 10 SDK
- MySQL ou MariaDB
- `dotnet-ef` instalado se quiser executar migrations manualmente

## Configuração do banco de dados

O projeto usa `Pomelo.EntityFrameworkCore.MySql` e há duas strings de conexão definidas em `AdminSiste/appsettings.json`:

- `DefaultConnection`
- `HomologacaoConnection`

No `Program.cs`, a aplicação utiliza `HomologacaoConnection` como padrão e possui um fallback para a string de conexão manual.

### Exemplo de conexão MySQL

```json
"ConnectionStrings": {
  "HomologacaoConnection": "server=localhost;port=3306;database=homologacao;user=hmg;password=010101"
}
```

## Executando a aplicação

1. Abra o terminal na pasta do projeto:

```powershell
cd AdminSiste
```

2. Atualize o banco de dados com migrations:

```powershell
dotnet ef database update
```

3. Inicie o servidor em modo de desenvolvimento:

```powershell
dotnet watch run
```

4. Acesse a aplicação em `https://localhost:5001` ou `http://localhost:5000`.

## Observações

- O projeto cria o banco de dados automaticamente com `db.Database.EnsureCreated()` e aplica seed inicial no startup.
- Se desejar alterar as credenciais do MySQL, atualize `AdminSiste/appsettings.json` ou a string de conexão no `Program.cs`.
- Rotas principais:
  - `/Login`
  - `/Logout`
  - `/Dashboard`
  - `/Admin`
  - `/Modulo`
  - `/Cliente/ClienteCadastro`
  - `/Cliente/ListaClientes`
  - `/Produto/ProdutoCadastro`
  - `/Produto/ProdutoLista`
  - `/Servico/ServicoCadastro`
  - `/Servico/ServicoLista`

## Estrutura de pastas

- `AdminSiste/Controllers`
- `AdminSiste/Data`
- `AdminSiste/Models`
- `AdminSiste/Pages`
- `AdminSiste/Services`
- `AdminSiste/wwwroot`

## Contato

Use este README como base para entender a aplicação e ajustar configurações conforme necessário.



