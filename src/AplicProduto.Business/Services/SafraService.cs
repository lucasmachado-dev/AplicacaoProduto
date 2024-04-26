using AplicProduto.Business.Interfaces;
using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Interfaces.Services;
using AplicProduto.Business.Models;
using AplicProduto.Business.Models.Validations;

namespace AplicProduto.Business.Services
{
    public class SafraService : BaseService, ISafraService
    {
        private readonly ISafraRepository _sasfraRepository;
        public SafraService(ISafraRepository sasfraRepository,
                            INotificador notificador) : base(notificador)
        {
            _sasfraRepository = sasfraRepository;
        }
        public async Task Create(Safra safra)
        {
            if (!ExecutarValidacao(new SafraValidation(), safra)) return;
            await _sasfraRepository.Adicionar(safra);
        }
        public async Task Update(Safra safra)
        {
            if (!ExecutarValidacao(new SafraValidation(), safra)) return;
            await _sasfraRepository.Atualizar(safra);
        }

        public async Task Delete(Guid id)
        {
            await _sasfraRepository.Remover(id);
        }


    }
}
