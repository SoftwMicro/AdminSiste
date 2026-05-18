using Microsoft.AspNetCore.Mvc.RazorPages;
using AdminSiste.Models.Servico;
using AdminSiste.Services.Servico;

namespace AdminSiste.Pages.Servico
{
    public class ServicoListaModel : PageModel
    {
        private readonly ServicoService _servicoService;
        public List<Models.Servico.Servico> Servicos { get; set; }

        public ServicoListaModel(ServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        public async Task OnGetAsync()
        {
            Servicos = await _servicoService.ListarTodosAsync();
        }
    }
}
