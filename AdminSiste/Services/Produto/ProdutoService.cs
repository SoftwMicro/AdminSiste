using ProdutoModel = AdminSiste.Models.Produto.Produto;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AdminSiste.Services.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly Data.AppDbContext _context;
        public ProdutoService(Data.AppDbContext context)
        {
            _context = context;
        }
        public void Salvar(ProdutoModel produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }
        public void Atualizar(ProdutoModel produto)
        {
            var existente = _context.Produtos
                .Include(p => p.Detalhes)
                .Include(p => p.Preco)
                .Include(p => p.Estoque)
                .FirstOrDefault(p => p.Id == produto.Id);
            if (existente == null) throw new System.Exception("Produto não encontrado");
            existente.Nome = produto.Nome;
            existente.Codigo = produto.Codigo;
            existente.CodigoBarra = produto.CodigoBarra;
            existente.GrupoProdutoId = produto.GrupoProdutoId;
            existente.MovimentaEstoque = produto.MovimentaEstoque;
            existente.PossuiNotaFiscal = produto.PossuiNotaFiscal;
            existente.PossuiVariacao = produto.PossuiVariacao;
            existente.PossuiComposicao = produto.PossuiComposicao;
            existente.UnidadeEntradaId = produto.UnidadeEntradaId;
            existente.QuantidadeSaida = produto.QuantidadeSaida;
            existente.UnidadeSaidaId = produto.UnidadeSaidaId;
            existente.Detalhes = produto.Detalhes;
            existente.Preco = produto.Preco;
            existente.Estoque = produto.Estoque;
            _context.SaveChanges();
        }
        public void Excluir(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }
        public ProdutoModel ObterPorIdCompleto(int id)
        {
            return _context.Produtos
                .Include(p => p.Detalhes)
                .Include(p => p.Preco)
                .Include(p => p.Estoque)
                .FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<ProdutoModel> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}