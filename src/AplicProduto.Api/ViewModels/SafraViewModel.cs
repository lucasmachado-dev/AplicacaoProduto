namespace AplicProduto.Api.ViewModels
{
    public class SafraViewModel : EntityViewModel
    {
        public SafraViewModel()
        {
            Ativo = true;
        }
        public string? Descricao { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
        public bool Ativo { get; set; }
    }
}
