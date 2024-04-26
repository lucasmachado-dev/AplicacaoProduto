namespace AplicProduto.Business.Models
{
    public class Talhao : Entity
    {
        public Guid FazendaId { get; set; }
        public string? Identificacao { get; set; }
        public decimal Area { get; set; }
        public Fazenda? Fazenda { get; set; }

    }
}
