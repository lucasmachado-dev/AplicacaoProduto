using AplicProduto.Business.Models;

namespace AplicProduto.Api.ViewModels
{
    public class CicloProducaoViewModel : EntityViewModel
    {
        public Guid SafraId { get; set; }
        public Guid CulturaId { get; set; }
        public string? Descricao { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
    }
}
