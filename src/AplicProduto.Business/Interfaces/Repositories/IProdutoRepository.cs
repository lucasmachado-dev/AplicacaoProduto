using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Repositories
{
    public interface IProdutoRepository: IRepository<Produto>
    {
        Task<bool> ProdutoExiste(Guid Id);
        Task<decimal> ValorProduto(Guid Id);
    }
}
