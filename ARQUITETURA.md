# Arquitetura da Aplicação

## Estrutura de Pastas

```
Admin.sln
README.md
AdminSiste/
├── AdminSiste.csproj
├── appsettings.Development.json
├── appsettings.json
├── Program.cs
├── bin/
│   └── ... (arquivos de build)
├── Data/
│   └── AppDbContext.cs
├── Migrations/
│   ├── ... (migrations do EF Core)
│   └── AppDbContextModelSnapshot.cs
├── Models/
│   └── Usuario.cs
├── obj/
│   └── ... (arquivos temporários de build)
├── Pages/
│   ├── _ViewImports.cshtml
│   ├── _ViewStart.cshtml
│   ├── Admin.cshtml
│   ├── Admin.cshtml.cs
│   ├── Dashboard.cshtml
│   ├── Dashboard.cshtml.cs
│   ├── Error.cshtml
│   ├── Error.cshtml.cs
│   ├── Index.cshtml
│   ├── Index.cshtml.cs
│   ├── Login.cshtml
│   ├── Login.cshtml.cs
│   ├── Logout.cshtml
│   ├── Logout.cshtml.cs
│   ├── Modulo.cshtml
│   ├── Modulo.cshtml.cs
│   └── Shared/
│       ├── _Layout.cshtml
│       └── _ValidationScriptsPartial.cshtml
├── Properties/
│   └── launchSettings.json
├── publish/
│   └── ... (arquivos publicados)
├── Services/
│   ├── AuthService.cs
│   └── FakeAuthService.cs
├── wwwroot/
│   ├── css/
│   │   ├── site.css
│   │   └── style.css
│   ├── img/
│   ├── js/
│   │   ├── login.js
│   │   └── site.js
│   └── lib/
│       ├── bootstrap/
│       ├── jquery/
│       ├── jquery-validation/
│       └── jquery-validation-unobtrusive/
├── mds/
│   ├── autenticacao.md
│   ├── Dashboard.md
│   ├── integracaoBancoDadosMysql.md
│   ├── loginfluxo.md
│   ├── menu.md
│   ├── moduloconteudo.md
│   └── rfcliente.md
```

## Descrição dos Principais Componentes

- **Program.cs**: Ponto de entrada da aplicação.
- **Data/AppDbContext.cs**: Contexto do Entity Framework para acesso ao banco de dados.
- **Migrations/**: Scripts de migração do banco de dados.
- **Models/**: Modelos de dados (ex: Usuario).
- **Pages/**: Páginas Razor (views e lógica associada).
- **Services/**: Serviços de autenticação e lógica de negócio.
- **wwwroot/**: Arquivos estáticos (CSS, JS, imagens, bibliotecas).
- **appsettings.json**: Configurações da aplicação.
- **mds/**: Documentação em Markdown.
