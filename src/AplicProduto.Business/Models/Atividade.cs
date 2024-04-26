namespace AplicProduto.Business.Models
{
    public class Atividade : Entity
    {
        public TipoAtividade TipoAtividade { get; set; }
        public string? Descricao { get; set; }      

    }
}
