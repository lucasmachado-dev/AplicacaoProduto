using AplicProduto.Business.Models;

namespace AplicProduto.Business.Interfaces.Services
{
    public interface IAplicacaoItemService
    {
        Task Create(AplicacaoItem aplicacaoItem);
        Task Update(AplicacaoItem aplicacaoItem);
        Task Delete(Guid id);
     
    }
}
