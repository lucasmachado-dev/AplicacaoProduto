using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Services
{
    public interface IFazendaService
    {
        Task Create(Fazenda fazenda);
        Task Update(Fazenda fazenda);
        Task Delete(Guid id);
    }
}
