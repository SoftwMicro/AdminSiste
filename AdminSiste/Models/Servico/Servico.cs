using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace AdminSiste.Models.Servico
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CodigoInterno { get; set; } // Gerado automaticamente

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorCusto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorVenda { get; set; }

        public decimal Comissao { get; set; } // Percentual

        public string Descricao { get; set; }

        public ServicoAtividade Atividade { get; set; }
        public ServicoImpostos Impostos { get; set; }

        // Configurações adicionais
        public bool DescontarImpostos { get; set; }
        public bool ConstrucaoCivil { get; set; }
        public bool DescontarDeducoes { get; set; }
        public bool BeneficioMunicipal { get; set; }

        // Upload de arquivos (caminho ou nome do arquivo)
       
        [ValidateNever]
        public string ArquivoUpload { get; set; }
    }
}
