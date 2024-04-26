using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Services
{
    public interface IAtividadeService
    {
        Task Create(Atividade atividade);
        Task Update(Atividade atividade);
        Task Delete(Guid id);
    }
}
