using ClienteModel = AdminSiste.Models.Cliente.Cliente;
using System.Collections.Generic;

namespace AdminSiste.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        private static List<ClienteModel> _clientes = new List<ClienteModel>(); // Mock temporário

        public void Salvar(ClienteModel cliente)
        {
            _clientes.Add(cliente);
        }

        public IEnumerable<ClienteModel> ListarTodos()
        {
            return _clientes;
        }
    }
}