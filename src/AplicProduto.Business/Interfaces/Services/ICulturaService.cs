using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Services
{
    public interface ICulturaService
    {
        Task Create(Cultura cultura);
        Task Update(Cultura cultura);
        Task Delete(Guid id);
    }
}
