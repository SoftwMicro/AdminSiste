using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AdminSiste.Models.Produto
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Nome { get; set; }

        [MaxLength(30)]
        public string Codigo { get; set; }

        [MaxLength(50)]
        public string CodigoBarra { get; set; }

        public int GrupoProdutoId { get; set; }
        public bool MovimentaEstoque { get; set; }
        public bool PossuiNotaFiscal { get; set; }
        public bool PossuiVariacao { get; set; }
        public bool PossuiComposicao { get; set; }
        public string UnidadeEntradaId { get; set; }
        public decimal QuantidadeSaida { get; set; }
        public string UnidadeSaidaId { get; set; }
        
        public ProdutoDetalhes Detalhes { get; set; }
        public Preco Preco { get; set; }
        public Estoque Estoque { get; set; }
    }
}