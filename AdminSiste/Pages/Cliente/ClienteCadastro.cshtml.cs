using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClienteModel = AdminSiste.Models.Cliente.Cliente;

namespace AdminSiste.Pages.Cliente
{
    public class ClienteCadastroModel : PageModel
    {
        [BindProperty]
        public ClienteModel Cliente { get; set; }

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
            // Salvar Cliente no banco de dados (implementar Service/Data)
            // Exemplo: _clienteService.Salvar(Cliente);
            return RedirectToPage("/Cliente/ClienteCadastro");
        }
    }
}