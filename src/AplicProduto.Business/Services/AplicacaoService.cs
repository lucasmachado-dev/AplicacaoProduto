using AplicProduto.Business.Interfaces;
using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Interfaces.Services;
using AplicProduto.Business.Models;
using AplicProduto.Business.Models.Validations;

namespace AplicProduto.Business.Services
{
    public class AplicacaoService : BaseService, IAplicacaoService

    {
        private readonly IAplicacaoRepository _aplicacaoRepository;
        private readonly ISafraRepository _safraRepository;  
        public AplicacaoService(IAplicacaoRepository aplicacaoRepository, 
                                ISafraRepository safraRepository,
                                INotificador notificador) : base(notificador)
        {
            _aplicacaoRepository = aplicacaoRepository;
            _safraRepository = safraRepository;

        }
        public async Task Create(Aplicacao aplicProduto)
        {
            if (!ExecutarValidacao(new AplicacaoValidation(), aplicProduto)) return;
            await _aplicacaoRepository.Adicionar(aplicProduto);
        }

        public async Task Update(Aplicacao aplicProduto)
        {
            if (!ExecutarValidacao(new AplicacaoValidation(), aplicProduto)) return;
            await _aplicacaoRepository.Atualizar(aplicProduto);
        }
        public async Task Delete(Guid id)
        {
            var aplicacao = await _aplicacaoRepository.BuscarPorId(id);
            if (aplicacao == null)
            {
                Notificar("Aplicação não encontrada.");
                return;
            }

            await _aplicacaoRepository.Remover(id);
        }
    }
}
