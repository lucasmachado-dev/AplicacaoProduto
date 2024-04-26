using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Services
{
    public interface ISafraService
    {
        Task Create(Safra safra);
        Task Update(Safra safra);
        Task Delete(Guid id);
        
    }
}
