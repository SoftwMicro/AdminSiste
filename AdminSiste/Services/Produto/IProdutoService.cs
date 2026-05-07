using ProdutoModel =  AdminSiste.Models.Produto.Produto;
using System.Collections.Generic;

namespace AdminSiste.Services.Produto
{
    public interface IProdutoService
    {
        void Salvar(ProdutoModel produto);
        void Atualizar(ProdutoModel produto);
        void Excluir(int id);
        ProdutoModel ObterPorIdCompleto(int id);
        IEnumerable<ProdutoModel> ListarTodos();
    }
}