namespace AplicProduto.Api.ViewModels
{
    public class TalhaoViewModel : EntityViewModel
    {
        public Guid FazendaId { get; set; }
        public string? Identificacao { get; set; }
        public decimal Area { get; set; }
    }
}
