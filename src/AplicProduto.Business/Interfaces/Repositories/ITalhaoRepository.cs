using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Repositories
{
    public interface ITalhaoRepository : IRepository<Talhao>
    {
        Task<bool> ExiteTalhao(Guid idTalhao);
        Task<Guid> FazendaDoTalhao(Guid Id);
    }
}
