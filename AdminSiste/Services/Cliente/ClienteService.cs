
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
        public void Atualizar(ClienteModel cliente)
        {
            if (cliente == null || cliente.Id <= 0)
                throw new System.Exception("Cliente inválido para atualização");
            if (cliente.Enderecos == null || !cliente.Enderecos.Any())
                throw new System.Exception("Endereço obrigatório");
            if (cliente.Contatos == null || !cliente.Contatos.Any())
                throw new System.Exception("Contato obrigatório");

            var existente = _context.Clientes
                .Include(c => c.Enderecos)
                .Include(c => c.Contatos)
                .FirstOrDefault(c => c.Id == cliente.Id);
            if (existente == null)
                throw new System.Exception("Cliente não encontrado para atualização");

            // Atualizar propriedades principais
            existente.Nome = cliente.Nome;
            existente.Email = cliente.Email;
            existente.Telefone = cliente.Telefone;
            existente.Celular = cliente.Celular;
            existente.Fax = cliente.Fax;
            existente.Site = cliente.Site;
            existente.TipoPessoa = cliente.TipoPessoa;
            existente.Situacao = cliente.Situacao;
            existente.Vendedor = cliente.Vendedor;

            // Atualizar endereços e contatos (simples: remove e adiciona)
            existente.Enderecos.Clear();
            foreach (var end in cliente.Enderecos)
                existente.Enderecos.Add(end);
            existente.Contatos.Clear();
            foreach (var cont in cliente.Contatos)
                existente.Contatos.Add(cont);

            _context.SaveChanges();
        }
    }
}