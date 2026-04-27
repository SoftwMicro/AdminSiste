using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using AdminSiste.Services;

public class LoginModel(FakeAuthService auth) : PageModel
{
    private readonly FakeAuthService _auth = auth;

    [BindProperty] public string? Username { get; set; }
    [BindProperty] public string? Password { get; set; }
    public string? ErrorMessage { get; set; }

    public void OnGet()
    {
        ErrorMessage = string.Empty;
    }

    public async Task<IActionResult> OnPost()
    {
        if (_auth.Login(Username, Password))
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, Username) };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToPage("/Admin");
        }

        ErrorMessage = "Usuário ou senha inválidos";
        return Page();
    }
}