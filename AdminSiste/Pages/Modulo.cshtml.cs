using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminSiste.Pages
{
    [Authorize]
    public class ModuloModel : PageModel
    {
        public void OnGet()
        {
            // Lógica de inicialização, se necessário
        }
    }
}
