using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Repositories
{
    public interface IFazendaRepository: IRepository<Fazenda>
    {
        Task<bool> ExisteFazenda(Guid idFazenda);
    }
}
