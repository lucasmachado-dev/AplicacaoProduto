namespace AplicProduto.Business.Models
{
    public class AplicacaoItem : Entity
    {
        public Guid AplicacaoId { get; set; }
        public Guid ProdutoId { get; set; }
        public decimal QuantidadeAplicada { get; set; }
        public decimal Valor { get; set; }

        public Aplicacao? Aplicacao { get; set; }
        public Produto? Produto { get; set; }


    }
}
