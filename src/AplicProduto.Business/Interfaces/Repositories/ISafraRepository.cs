using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Repositories
{
    public interface ISafraRepository: IRepository<Safra>
    {
        Task<bool> SafraAtiva(Guid Id);
    }
}
