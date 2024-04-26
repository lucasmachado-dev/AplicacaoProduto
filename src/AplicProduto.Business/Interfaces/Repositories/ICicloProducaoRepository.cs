using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Repositories
{
    public interface ICicloProducaoRepository : IRepository<CicloProducao>
    {
        Task<bool> ExisteCiclo(Guid Id);
        Task<Guid> CulturaDoCiclo(Guid Id);
    }
}
