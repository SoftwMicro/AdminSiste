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
        [BindProperty]
        public AdminSiste.Models.Cliente.Endereco Endereco { get; set; }
        [BindProperty]
        public AdminSiste.Models.Cliente.Contato Contato { get; set; }

        [TempData]
        public string MensagemSucesso { get; set; }

        public void OnGet()
        {
            // Inicialização se necessário
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                // Ajuste: apenas um endereço e um contato
                if (Endereco != null && !string.IsNullOrWhiteSpace(Endereco.CEP))
                    Cliente.Enderecos = new List<AdminSiste.Models.Cliente.Endereco> { Endereco };
                else
                    Cliente.Enderecos = new List<AdminSiste.Models.Cliente.Endereco>();

                if (Contato != null && !string.IsNullOrWhiteSpace(Contato.Email))
                    Cliente.Contatos = new List<AdminSiste.Models.Cliente.Contato> { Contato };
                else
                    Cliente.Contatos = new List<AdminSiste.Models.Cliente.Contato>();

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