using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Services
{
    public interface ITalhaoService
    {
        Task Create(Talhao talhao);
        Task Update(Talhao talhao);
        Task Delete(Guid id);
    }
}
