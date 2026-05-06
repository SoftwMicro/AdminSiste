using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdminSiste.Services.Cliente;
using System.Collections.Generic;

namespace AdminSiste.Pages.Cliente
{
    public class ListaClientesModel : PageModel
    {
        private readonly Services.Cliente.IClienteService _clienteService;
        public ListaClientesModel(Services.Cliente.IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public List<ListaClienteEssencialDto> Clientes { get; set; }

        public void OnGet()
        {
            Clientes = _clienteService.ListarEssenciais().ToList();
        }

        public IActionResult OnPostExcluir(int id)
        {
            _clienteService.Excluir(id);
            return RedirectToPage();
        }
    }
}
