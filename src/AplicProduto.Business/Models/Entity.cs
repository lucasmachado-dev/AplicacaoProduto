namespace AplicProduto.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime DataInsert { get; set; }
        public DateTime DataUpdate { get; set; }
    }
}
