using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Services
{
    public interface IProdutoService
    {
        Task Create(Produto produto);
        Task Update(Produto produto);
        Task Delete(Guid id);
    }
}
