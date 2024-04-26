namespace AplicProduto.Business.Models
{
    public class Aplicacao : Entity
    {
        public Guid FazendaId { get; set; }
        public Guid SafraId { get; set; }
        public Guid TalhaoId { get; set; }
        public Guid CicloProducaoId { get; set; }
        public Guid AtividadeId { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFinal { get; set; }
        public bool Executada { get; set; }
        public IEnumerable<AplicacaoItem>? AplicacaoItem { get; set; }

        public Fazenda? Fazenda { get; set; }
        public Safra? Safra { get; set; }
        public Talhao? Talhao { get; set; }
        public CicloProducao? CicloProducao { get; set; }
        public Atividade? Atividade { get; set; }
    }
}
