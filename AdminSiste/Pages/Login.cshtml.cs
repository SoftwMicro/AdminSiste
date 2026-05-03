using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using AdminSiste.Services;


using AdminSiste.Models;
using AdminSiste.Data;
using Microsoft.EntityFrameworkCore;
using AdminSiste.Services;

public class LoginModel(AuthService auth) : PageModel
{
    private readonly AuthService _auth = auth;


    [BindProperty] public string? Email { get; set; }
    [BindProperty] public string? Password { get; set; }
    public string? ErrorMessage { get; set; }

    public void OnGet()
    {
        ErrorMessage = string.Empty;
    }

    public async Task<IActionResult> OnPost()
    {
        if (Email != null && Password != null)
        {
            var usuario = _auth.ValidarLogin(Email, Password);
            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Email),
                    new Claim("NomeCompleto", usuario.NomeCompleto)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToPage("/Modulo");
            }
        }
        ErrorMessage = "Usuário ou senha inválidos";
        return Page();
    }
}