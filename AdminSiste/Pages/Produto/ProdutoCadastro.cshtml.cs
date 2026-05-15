using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProdutoModel = AdminSiste.Models.Produto.Produto;
using ProdutoModelDetalhes = AdminSiste.Models.Produto.ProdutoDetalhes;
using ProdutoModelPreco = AdminSiste.Models.Produto.Preco;
using ProdutoModelEstoque = AdminSiste.Models.Produto.Estoque;
using AdminSiste.Services.Produto;

namespace AdminSiste.Pages.Produto
{
    public class ProdutoCadastroModel : PageModel
    {
        private readonly IProdutoService _produtoService;
        public ProdutoCadastroModel(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        [BindProperty]
        public ProdutoModel Produto { get; set; }
        [TempData]
        public string MensagemSucesso { get; set; }
        public void OnGet(int? id = null)
        {
            if (id.HasValue)
            {
                Produto = _produtoService.ObterPorIdCompleto(id.Value);
            }
            if (Produto == null)
            {
                Produto = new ProdutoModel
                {
                    Detalhes = new ProdutoModelDetalhes(),
                    Preco = new ProdutoModelPreco(),
                    Estoque = new ProdutoModelEstoque()
                };
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                if (Produto == null)
                    Produto = new ProdutoModel();
                if (Produto.Detalhes == null)
                    Produto.Detalhes = new ProdutoModelDetalhes();
                if (Produto.Preco == null)
                    Produto.Preco = new ProdutoModelPreco();
                if (Produto.Estoque == null)
                    Produto.Estoque = new ProdutoModelEstoque();
                return Page();
            }
            try
            {
                if (Produto.Id > 0)
                {
                    _produtoService.Atualizar(Produto);
                    MensagemSucesso = "Edição realizada com sucesso!";
                }
                else
                {
                    _produtoService.Salvar(Produto);
                    MensagemSucesso = "Cadastro realizado com sucesso!";
                }
                return RedirectToPage("/Produto/ProdutoLista");
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}
