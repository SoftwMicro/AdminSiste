using ClienteModel = AdminSiste.Models.Cliente.Cliente;
using System.Collections.Generic;

namespace AdminSiste.Services.Cliente
{
    public interface IClienteService
    {
        void Salvar(ClienteModel cliente);
        IEnumerable<ClienteModel> ListarTodos();
        // Outros métodos conforme necessidade
    }
}