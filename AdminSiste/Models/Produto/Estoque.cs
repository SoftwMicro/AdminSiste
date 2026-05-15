using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AdminSiste.Models.Produto
{
    public class Estoque
    {
        public int Id { get; set; }
        public decimal EstoqueMinimo { get; set; }
        public decimal EstoqueMaximo { get; set; }
        public decimal QuantidadeAtual { get; set; }
        // Relacionamento reverso
        public int ProdutoId { get; set; }
         [ValidateNever]
        public Produto Produto { get; set; }
    }
}