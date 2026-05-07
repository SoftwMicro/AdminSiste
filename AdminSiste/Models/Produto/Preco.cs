namespace AdminSiste.Models.Produto
{
    public class Preco
    {
        public int Id { get; set; }
        public decimal ValorCustoMedio { get; set; }
        public decimal ValorDespesasAcessorias { get; set; }
        public decimal ValorOutrasDespesas { get; set; }
        public decimal ValorCusto { get; set; }
        // Relacionamento reverso
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}