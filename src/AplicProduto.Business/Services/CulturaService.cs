using AplicProduto.Business.Interfaces;
using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Interfaces.Services;
using AplicProduto.Business.Models;
using AplicProduto.Business.Models.Validations;

namespace AplicProduto.Business.Services
{
    public class CulturaService : BaseService, ICulturaService
    {
        private readonly ICulturaRepository _culturaRepository;

        public CulturaService(ICulturaRepository culturaRepository,
                              INotificador notificador) : base(notificador)
        {
            _culturaRepository = culturaRepository;
        }
        public async Task Create(Cultura cultura)
        {
            if (!ExecutarValidacao(new CulturaValidation(), cultura)) return;
            await _culturaRepository.Adicionar(cultura);
        }

        public async Task Delete(Guid id)
        {
            await _culturaRepository.Remover(id);
        }

        public async Task Update(Cultura cultura)
        {
            if (!ExecutarValidacao(new CulturaValidation(), cultura)) return;
            await _culturaRepository.Atualizar(cultura);
        }
    }
}
