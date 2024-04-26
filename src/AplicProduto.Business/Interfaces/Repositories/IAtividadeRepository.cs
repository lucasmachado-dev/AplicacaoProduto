using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Repositories
{
    public interface IAtividadeRepository : IRepository<Atividade>
    {
        Task<bool> ExisteAtividade(Guid Id);
    }
}
