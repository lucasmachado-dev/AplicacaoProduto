using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Services
{
    public interface IAplicacaoService
    {
        Task Create(Aplicacao aplicProduto);
        Task Update(Aplicacao aplicProduto);
        Task Delete(Guid id);
    }
}
