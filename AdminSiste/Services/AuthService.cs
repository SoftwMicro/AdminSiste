using AdminSiste.Data;
using AdminSiste.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminSiste.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public Usuario? ValidarLogin(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
