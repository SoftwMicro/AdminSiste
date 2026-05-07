namespace AdminSiste.Models.Produto
{
    public class ProdutoDetalhes
    {
        public int Id { get; set; }
        public decimal Peso { get; set; }
        public decimal Largura { get; set; }
        public decimal Altura { get; set; }
        public decimal Comprimento { get; set; }
        public bool Ativo { get; set; }
        public bool VendidoSeparadamente { get; set; }
        public bool ComercializavelPDV { get; set; }
        public decimal Comissao { get; set; }
        public string Descricao { get; set; }
    }
}