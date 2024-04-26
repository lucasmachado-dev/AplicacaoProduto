using AplicProduto.Business.Interfaces;
using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Interfaces.Services;
using AplicProduto.Business.Models;
using AplicProduto.Business.Models.Validations;

namespace AplicProduto.Business.Services
{
    public class FazendaService : BaseService, IFazendaService
    {
        private readonly IFazendaRepository _fazendaRepository;

        public FazendaService(IFazendaRepository fazendaRepository,
                              INotificador notificador) : base(notificador)
        {
            _fazendaRepository = fazendaRepository;
        }
        public async Task Create(Fazenda fazenda)
        {
            if (!ExecutarValidacao(new FazendaValidation(), fazenda)) return;
            await _fazendaRepository.Adicionar(fazenda);
        }

        public async Task Update(Fazenda fazenda)
        {
            if (!ExecutarValidacao(new FazendaValidation(), fazenda)) return;
            await _fazendaRepository.Atualizar(fazenda);
        }

        public async Task Delete(Guid id)
        {
            await _fazendaRepository.Remover(id);
        }
    }
}
