using ClienteModel = AdminSiste.Models.Cliente.Cliente;
using System.Collections.Generic;

namespace AdminSiste.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly Data.AppDbContext _context;

        public ClienteService(Data.AppDbContext context)
        {
            _context = context;
        }

        public void Salvar(ClienteModel cliente)
        {
            if (cliente.Enderecos == null || !cliente.Enderecos.Any())
                throw new System.Exception("Endereço obrigatório");
            if (cliente.Contatos == null || !cliente.Contatos.Any())
                throw new System.Exception("Contato obrigatório");

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public IEnumerable<ClienteModel> ListarTodos()
        {
            return _context.Clientes.ToList();
        }
    }
}