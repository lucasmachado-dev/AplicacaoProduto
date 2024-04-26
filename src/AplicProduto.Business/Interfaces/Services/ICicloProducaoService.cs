using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Services
{
    public interface ICicloProducaoService
    {
        Task Create(CicloProducao cicloProducao);
        Task Update(CicloProducao cicloProducao);
        Task Delete(Guid id);
    }
}
