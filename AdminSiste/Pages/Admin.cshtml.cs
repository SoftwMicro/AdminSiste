using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

[Authorize]
public class AdminModel : PageModel
{
    public void OnGet()
    {
    }
}