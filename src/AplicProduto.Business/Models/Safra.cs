namespace AplicProduto.Business.Models
{
    public class Safra : Entity
    {
        public Safra()
        {
            Ativo = true;
        }
        public string? Descricao { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
        public bool Ativo { get; set; }
    }
}
