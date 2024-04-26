using AplicProduto.Business.Models;

namespace AplicProduto.Api.ViewModels
{
    public class AtividadeViewModel : EntityViewModel
    {
        public int TipoAtividade { get; set; }
        public string? Descricao { get; set; }
    }
}
