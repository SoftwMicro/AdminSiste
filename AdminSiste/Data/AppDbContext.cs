using Microsoft.EntityFrameworkCore;
using AdminSiste.Models;

namespace AdminSiste.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public void Seed()
        {
            if (!Usuarios.Any())
            {
                Usuarios.Add(new Usuario
                {
                    Email = "admin@admin.com",
                    NomeCompleto = "Administrador",
                    Username = "admin",
                    Senha = "123456"
                });
                SaveChanges();
            }
        }
    }
}
