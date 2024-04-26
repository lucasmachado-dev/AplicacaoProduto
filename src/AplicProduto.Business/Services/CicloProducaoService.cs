using AplicProduto.Business.Interfaces;
using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Interfaces.Services;
using AplicProduto.Business.Models;
using AplicProduto.Business.Models.Validations;

namespace AplicProduto.Business.Services
{
    public class CicloProducaoService : BaseService, ICicloProducaoService
    {
        private readonly ICicloProducaoRepository _cicloProducaoRepository;

        public CicloProducaoService(ICicloProducaoRepository cicloProducaoRepository,
                                    INotificador notificador) : base(notificador)
        {
            _cicloProducaoRepository = cicloProducaoRepository;
        }
        public async Task Create(CicloProducao cicloProducao)
        {
            if (!ExecutarValidacao(new CicloProducaoValidation(), cicloProducao)) return;
            await _cicloProducaoRepository.Adicionar(cicloProducao);
        }

        public async Task Update(CicloProducao cicloProducao)
        {
            if (!ExecutarValidacao(new CicloProducaoValidation(), cicloProducao)) return;
            await _cicloProducaoRepository.Atualizar(cicloProducao);
        }

        public async Task Delete(Guid id)
        {
            await _cicloProducaoRepository.Remover(id);
        }
    }
}
