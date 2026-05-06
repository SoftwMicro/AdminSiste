
        using ClienteModel = AdminSiste.Models.Cliente.Cliente;
        using System.Collections.Generic;
        using Microsoft.EntityFrameworkCore;

namespace AdminSiste.Services.Cliente
{

    public class ClienteService : IClienteService
    {
        private readonly Data.AppDbContext _context;

        public ClienteService(Data.AppDbContext context)
        {
            _context = context;
        }

        public ClienteModel ObterPorIdCompleto(int id)
        {
            return _context.Clientes
                .Where(c => c.Id == id)
                .Include(c => c.Enderecos)
                .Include(c => c.Contatos)
                .FirstOrDefault();
        }


        void IClienteService.Salvar(ClienteModel cliente)
        {
            if (cliente.Enderecos == null || !cliente.Enderecos.Any())
                throw new System.Exception("Endereço obrigatório");
            if (cliente.Contatos == null || !cliente.Contatos.Any())
                throw new System.Exception("Contato obrigatório");

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public IEnumerable<ListaClienteEssencialDto> ListarEssenciais()
        {
            return _context.Clientes
                .Select(c => new ListaClienteEssencialDto
                {
                    Id = c.Id,
                    Tipo = c.TipoPessoa,
                    Ativo = c.Situacao == 1,
                    Nome = c.Nome,
                    Email = c.Email
                })
                .ToList();
        }

        public void Excluir(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }

        IEnumerable<ClienteModel> IClienteService.ListarTodos()
        {
            return _context.Clientes.ToList();
        }
    }
}