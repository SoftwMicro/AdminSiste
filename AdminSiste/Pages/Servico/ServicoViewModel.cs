namespace AdminSiste.Pages.Servico
{
    public class ServicoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CodigoInterno { get; set; } = string.Empty;
        public decimal ValorCusto { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal Comissao { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string AtividadeServico { get; set; } = string.Empty;
        public string CodigoServico { get; set; } = string.Empty;
        public string CodigoTributacao { get; set; } = string.Empty;
        public string CodigoNBS { get; set; } = string.Empty;
        public string CNAE { get; set; } = string.Empty;
        public string DescricaoAtividade { get; set; } = string.Empty;
        public decimal PercentualISS { get; set; }
        public decimal PercentualCOFINS { get; set; }
        public decimal PercentualPIS { get; set; }
        public decimal PercentualCSLL { get; set; }
        public decimal PercentualIR { get; set; }
        public decimal PercentualINSS { get; set; }
        public bool DescontarImpostos { get; set; }
        public bool ConstrucaoCivil { get; set; }
        public bool DescontarDeducoes { get; set; }
        public bool BeneficioMunicipal { get; set; }
        public string ArquivoUpload { get; set; } = string.Empty;
    }
}