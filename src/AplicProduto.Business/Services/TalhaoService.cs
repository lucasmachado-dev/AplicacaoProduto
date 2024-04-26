using AplicProduto.Business.Interfaces;
using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Interfaces.Services;
using AplicProduto.Business.Models;
using AplicProduto.Business.Models.Validations;

namespace AplicProduto.Business.Services
{
    public class TalhaoService : BaseService, ITalhaoService
    {
        private readonly ITalhaoRepository _talhaoRepository;
        public TalhaoService(ITalhaoRepository talhaoRepository,
                             INotificador notificador) : base(notificador)
        {
            _talhaoRepository = talhaoRepository;
        }
        public async Task Create(Talhao talhao)
        {
            if (!ExecutarValidacao(new TalhaoValidation(), talhao)) return;
            await _talhaoRepository.Adicionar(talhao);
        }
        public async Task Update(Talhao talhao)
        {
            if (!ExecutarValidacao(new TalhaoValidation(), talhao)) return;
            await _talhaoRepository.Atualizar(talhao);
        }
        public async Task Delete(Guid id)
        {
            await _talhaoRepository.Remover(id);
        }
    }
}
