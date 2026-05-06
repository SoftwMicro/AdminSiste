
using ClienteModel = AdminSiste.Models.Cliente.Cliente;
using System.Collections.Generic;

namespace AdminSiste.Services.Cliente
{
    public interface IClienteService
    {
        void Salvar(ClienteModel cliente);
        IEnumerable<ClienteModel> ListarTodos();

        /// <summary>
        /// Retorna apenas os campos essenciais para a listagem de clientes.
        /// </summary>
        IEnumerable<ListaClienteEssencialDto> ListarEssenciais();

        /// <summary>
        /// Remove um cliente pelo Id.
        /// </summary>
        void Excluir(int id);

        /// <summary>
        /// Busca um cliente completo (com endereços e contatos) pelo Id.
        /// </summary>
        ClienteModel ObterPorIdCompleto(int id);
        // Outros métodos conforme necessidade
    }
}