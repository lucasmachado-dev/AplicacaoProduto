namespace AplicProduto.Business.Models
{
    public class CicloProducao : Entity
    {
        public Guid SafraId { get; set; }
        public Guid CulturaId { get; set; }
        public string? Descricao { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }

        public Safra? Safra { get; set; }
        public Cultura? Cultura { get; set; }

    }
}
