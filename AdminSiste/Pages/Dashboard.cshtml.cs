using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Authorization;
[Authorize]
public class DashboardModel : PageModel
{
    public void OnGet()
    {
        // Aqui podemos carregar dados dinâmicos futuramente
    }
}
