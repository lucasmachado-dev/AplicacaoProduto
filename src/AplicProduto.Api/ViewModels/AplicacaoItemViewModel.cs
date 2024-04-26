namespace AplicProduto.Api.ViewModels
{
    public class AplicacaoItemViewModel : EntityViewModel
    {
        public Guid AplicacaoId { get; set; }
        public Guid ProdutoId { get; set; }
        public decimal QuantidadeAplicada { get; set; }
        public decimal Valor { get; set; }
    }
}
