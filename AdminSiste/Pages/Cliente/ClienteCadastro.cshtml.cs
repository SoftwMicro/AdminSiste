using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClienteModel = AdminSiste.Models.Cliente.Cliente;

namespace AdminSiste.Pages.Cliente
{
    [Authorize]
    public class ClienteCadastroModel : PageModel
    {
        private readonly Services.Cliente.IClienteService _clienteService;

        public ClienteCadastroModel(Services.Cliente.IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [BindProperty]
        public ClienteModel Cliente { get; set; }


        [TempData]
        public string MensagemSucesso { get; set; }

        public void OnGet(int? id = null)
        {
            if (id.HasValue)
            {
                // Buscar cliente completo para edição
                Cliente = _clienteService.ObterPorIdCompleto(id.Value);
            }
            if (Cliente == null)
                Cliente = new ClienteModel();
            if (Cliente.Enderecos == null || Cliente.Enderecos.Count == 0)
                Cliente.Enderecos = new List<AdminSiste.Models.Cliente.Endereco> { new AdminSiste.Models.Cliente.Endereco() };
            if (Cliente.Contatos == null || Cliente.Contatos.Count == 0)
                Cliente.Contatos = new List<AdminSiste.Models.Cliente.Contato> { new AdminSiste.Models.Cliente.Contato() };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                if (Cliente == null)
                    Cliente = new ClienteModel();
                if (Cliente.Enderecos == null || Cliente.Enderecos.Count == 0)
                    Cliente.Enderecos = new List<AdminSiste.Models.Cliente.Endereco> { new AdminSiste.Models.Cliente.Endereco() };
                if (Cliente.Contatos == null || Cliente.Contatos.Count == 0)
                    Cliente.Contatos = new List<AdminSiste.Models.Cliente.Contato> { new AdminSiste.Models.Cliente.Contato() };
                return Page();
            }
            try
            {
                if (Cliente.Id > 0)
                {
                    // Edição: buscar cliente existente, atualizar campos e salvar
                    var clienteExistente = _clienteService.ObterPorIdCompleto(Cliente.Id);
                    if (clienteExistente == null)
                    {
                        ModelState.AddModelError(string.Empty, "Cliente não encontrado para edição.");
                        return Page();
                    }
                    // Atualizar campos principais
                    clienteExistente.Nome = Cliente.Nome;
                    clienteExistente.Email = Cliente.Email;
                    clienteExistente.Telefone = Cliente.Telefone;
                    clienteExistente.Celular = Cliente.Celular;
                    clienteExistente.Fax = Cliente.Fax;
                    clienteExistente.Site = Cliente.Site;
                    clienteExistente.TipoPessoa = Cliente.TipoPessoa;
                    clienteExistente.Situacao = Cliente.Situacao;
                    clienteExistente.Vendedor = Cliente.Vendedor;
                    clienteExistente.Enderecos = Cliente.Enderecos;
                    clienteExistente.Contatos = Cliente.Contatos;
                    _clienteService.Atualizar(clienteExistente);
                    MensagemSucesso = "Edição realizada com sucesso!";
                }
                else
                {
                    // Novo cadastro
                    _clienteService.Salvar(Cliente);
                    MensagemSucesso = "Cadastro realizado com sucesso!";
                }
                return RedirectToPage("/Cliente/ClienteCadastro", new { id = Cliente.Id });
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}