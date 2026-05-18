using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProdutoModel = AdminSiste.Models.Produto.Produto;
using AdminSiste.Services.Produto;
using System.Collections.Generic;

namespace AdminSiste.Pages.Produto
{
    [Authorize]
    public class ProdutoListaModel : PageModel
    {
        private readonly IProdutoService _produtoService;
        public List<ProdutoModel> Produtos { get; set; }

        public ProdutoListaModel(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public void OnGet()
        {
            Produtos = new List<ProdutoModel>(_produtoService.ListarTodos());
        }

        public IActionResult OnPostDelete(int id)
        {
            _produtoService.Excluir(id);
            return RedirectToPage();
        }
    }
}