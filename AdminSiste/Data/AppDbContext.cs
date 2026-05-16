using Microsoft.EntityFrameworkCore;
using AdminSiste.Models;

namespace AdminSiste.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AdminSiste.Models.Cliente.Cliente> Clientes { get; set; }
        public DbSet<AdminSiste.Models.Cliente.Endereco> Enderecos { get; set; }
        public DbSet<AdminSiste.Models.Cliente.Contato> Contatos { get; set; }

        public DbSet<AdminSiste.Models.Produto.Produto> Produtos { get; set; }
        public DbSet<AdminSiste.Models.Produto.ProdutoDetalhes> ProdutoDetalhes { get; set; }
        public DbSet<AdminSiste.Models.Produto.Preco> Precos { get; set; }
        public DbSet<AdminSiste.Models.Produto.Estoque> Estoques { get; set; }

        public void Seed()
        {
                // Verificar se já existem dados para evitar duplicação
                //if (!Usuarios.Any())
                //{
                  //  Usuarios.Add(new Usuario { Nome = "Admin", Email = "admin@admin.com" });
                    //SaveChanges();
                //}
        }
    }
}
