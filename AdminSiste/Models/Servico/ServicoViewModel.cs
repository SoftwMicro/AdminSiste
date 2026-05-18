using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AdminSiste.Models.Servico
{
    public class ServicoViewModel
    {
        public int? Id { get; set; }

        // Dados Básicos
        [Required]
        public string Nome { get; set; }
        public string CodigoInterno { get; set; }
        public decimal ValorCusto { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal Comissao { get; set; }
        public string Descricao { get; set; }

        // Atividade e Classificação
        public string AtividadeServico { get; set; }
        public string CodigoServico { get; set; }
        public string CodigoTributacao { get; set; }
        public string CodigoNBS { get; set; }
        public string CNAE { get; set; }
        public string DescricaoAtividade { get; set; }

        
        // Impostos
        public decimal PercentualISS { get; set; }
        public decimal PercentualCOFINS { get; set; }
        public decimal PercentualPIS { get; set; }
        public decimal PercentualCSLL { get; set; }
        public decimal PercentualIR { get; set; }
        public decimal PercentualINSS { get; set; }

        // Configurações adicionais
        public bool DescontarImpostos { get; set; }
        public bool ConstrucaoCivil { get; set; }
        public bool DescontarDeducoes { get; set; }
        public bool BeneficioMunicipal { get; set; }

        // Upload (não obrigatório)
         [ValidateNever]
        public string ArquivoUpload { get; set; }
    }
}
