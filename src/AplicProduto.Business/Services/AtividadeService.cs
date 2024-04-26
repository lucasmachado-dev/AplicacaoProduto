using AplicProduto.Business.Interfaces;
using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Interfaces.Services;
using AplicProduto.Business.Models;
using AplicProduto.Business.Models.Validations;

namespace AplicProduto.Business.Services
{
    public class AtividadeService : BaseService, IAtividadeService
    {
        private readonly IAtividadeRepository _atividadeRepository;

        public AtividadeService(IAtividadeRepository atividadeRepository,
                                INotificador notificador) : base(notificador) 
        {
            _atividadeRepository = atividadeRepository;
        }
        public async Task Create(Atividade atividade)
        {
            if (!ExecutarValidacao(new AtividadeValidation(), atividade)) return;
            await _atividadeRepository.Adicionar(atividade);
        }

        public async Task Update(Atividade atividade)
        {
            if (!ExecutarValidacao(new AtividadeValidation(), atividade)) return;
            await _atividadeRepository.Atualizar(atividade);
        }
        public async Task Delete(Guid id)
        {
            await _atividadeRepository.Remover(id);
        }
    }
}
