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

public class LoginModel : PageModel
{
    private readonly AuthService _auth;
    private readonly AppDbContext _db;

    public LoginModel(AuthService auth, AppDbContext db)
    {
        _auth = auth;
        _db = db;
    }

    [BindProperty] public string? Email { get; set; }
    [BindProperty] public string? Password { get; set; }
    public string? ErrorMessage { get; set; }

    // Propriedades para cadastro
    [BindProperty] public string? CadastroEmail { get; set; }
    [BindProperty] public string? CadastroNomeCompleto { get; set; }
    [BindProperty] public string? CadastroSenha { get; set; }
    [BindProperty] public string? CadastroUsername { get; set; }
    public string? CadastroMensagem { get; set; }

    public void OnGet()
    {
        ErrorMessage = string.Empty;
        CadastroMensagem = string.Empty;
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

    public async Task<IActionResult> OnPostCadastroAsync()
    {
        // Validação básica
        if (string.IsNullOrWhiteSpace(CadastroEmail) || string.IsNullOrWhiteSpace(CadastroNomeCompleto) || string.IsNullOrWhiteSpace(CadastroSenha) || string.IsNullOrWhiteSpace(CadastroUsername))
        {
            CadastroMensagem = "Preencha todos os campos.";
            return Page();
        }

        // Verifica se já existe usuário
        if (_db.Usuarios.Any(u => u.Email == CadastroEmail))
        {
            CadastroMensagem = "E-mail já cadastrado.";
            return Page();
        }
        if (_db.Usuarios.Any(u => u.Username == CadastroUsername))
        {
            CadastroMensagem = "Nome de usuário já cadastrado.";
            return Page();
        }

        var novoUsuario = new Usuario
        {
            Email = CadastroEmail,
            NomeCompleto = CadastroNomeCompleto,
            Username = CadastroUsername,
            Senha = CadastroSenha // Em produção, use hash de senha!
        };
        _db.Usuarios.Add(novoUsuario);
        await _db.SaveChangesAsync();

        CadastroMensagem = "Cadastro realizado com sucesso! Faça login.";
        return Page();
    }
}