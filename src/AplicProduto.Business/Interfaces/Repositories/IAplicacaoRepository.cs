using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Repositories
{
    public interface IAplicacaoRepository : IRepository<Aplicacao>
    {
        Task<List<AplicacaoItem>> ObterItensAplicacao(Guid Id);
    }
}
