using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Interfaces.Services;
using AplicProduto.Business.Interfaces;
using AplicProduto.Business.Models.Validations;
using AplicProduto.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicProduto.Business.Services
{
    public class AplicacaoItemService : BaseService, IAplicacaoItemService
    {
        private readonly IAplicacaoItemRepository _aplicacaoItemRepository;

        public AplicacaoItemService(IAplicacaoItemRepository aplicacaoItemRepository,
                                INotificador notificador) : base(notificador)
        {
            _aplicacaoItemRepository = aplicacaoItemRepository;
        }
        public async Task Create(AplicacaoItem aplicacaoItem)
        {
            if (!ExecutarValidacao(new AplicacaoItemValidation(), aplicacaoItem)) return;
            await _aplicacaoItemRepository.Adicionar(aplicacaoItem);
        }

        public async Task Update(AplicacaoItem aplicacaoItem)
        {
            if (!ExecutarValidacao(new AplicacaoItemValidation(), aplicacaoItem)) return;
            await _aplicacaoItemRepository.Atualizar(aplicacaoItem);
        }
        public async Task Delete(Guid id)
        {
            await _aplicacaoItemRepository.Remover(id);
        }
    }
}
