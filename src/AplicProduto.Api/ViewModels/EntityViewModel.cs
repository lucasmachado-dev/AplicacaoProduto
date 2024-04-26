using System.Text.Json.Serialization;

namespace AplicProduto.Api.ViewModels
{
    public abstract class EntityViewModel
    {
        protected EntityViewModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime DataInsert { get; set; }
        public DateTime DataUpdate { get; set; }
    }
}
