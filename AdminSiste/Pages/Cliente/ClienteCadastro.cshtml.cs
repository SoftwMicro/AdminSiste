using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClienteModel = AdminSiste.Models.Cliente.Cliente;

namespace AdminSiste.Pages.Cliente
{
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

        public void OnGet()
        {
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
                _clienteService.Salvar(Cliente);
                MensagemSucesso = "Cadastro realizado com sucesso!";
                return RedirectToPage("/Cliente/ClienteCadastro");
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}