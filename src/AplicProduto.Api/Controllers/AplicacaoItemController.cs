using AplicProduto.Api.ViewModels;
using AplicProduto.Business.Interfaces;
using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Interfaces.Services;
using AplicProduto.Business.Models;
using AplicProduto.Business.Services;
using AplicProduto.Data.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AplicProduto.Api.Controllers
{
    [Route("api/aplicacao-itens")]
    public class AplicacaoItemController : MainController
    {
        private readonly IAplicacaoItemRepository _aplicacaoItemRepository;
        private readonly IAplicacaoItemService _aplicacaoItemService;
        private readonly IProdutoRepository _produtoRepository;

        private readonly IMapper _mapper;

        public AplicacaoItemController(IAplicacaoItemRepository aplicacaoItemRepository,
                                       IAplicacaoItemService aplicacaoItemService,
                                       IMapper mapper,
                                       INotificador notificador,
                                       IProdutoRepository produtoRepository) : base(notificador)
        {
            _aplicacaoItemRepository = aplicacaoItemRepository;
            _aplicacaoItemService = aplicacaoItemService;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<AplicacaoItemViewModel>> ObterItens()
        {
            return _mapper.Map<IEnumerable<AplicacaoItemViewModel>>(await _aplicacaoItemRepository.BuscarTodos());

        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<AplicacaoItemViewModel>> ObterItensPorId(Guid id)
        {
            var produto = _mapper.Map<AplicacaoItemViewModel>(await _aplicacaoItemRepository.BuscarPorId(id));

            if (produto == null) return NotFound();

            return produto;
        }

        [HttpPost]
        public async Task<ActionResult<AplicacaoItemViewModel>> Adicionar(AplicacaoItemViewModel aplicacaoItemViewModel)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            await ValidaPostAplicacaoItem(aplicacaoItemViewModel);
            var valorProduto = await _produtoRepository.ValorProduto(aplicacaoItemViewModel.ProdutoId);

            aplicacaoItemViewModel.Valor = aplicacaoItemViewModel.QuantidadeAplicada * valorProduto;

            await _aplicacaoItemService.Create(_mapper.Map<AplicacaoItem>(aplicacaoItemViewModel));

            return CustomReponse(HttpStatusCode.Created, aplicacaoItemViewModel);
        }


        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<AplicacaoItemViewModel>> Atualizar(AplicacaoItemViewModel aplicacaoItemViewModel, Guid id)
        {
            if (aplicacaoItemViewModel.Id != id)
            {
                NotificarErro("Os ids informados não são iguais");
                return CustomReponse();
            }

            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var aplicacaoItem = await ObterAplicacaoItem(id);

            aplicacaoItem.ProdutoId = aplicacaoItemViewModel.ProdutoId;
            aplicacaoItem.QuantidadeAplicada = aplicacaoItemViewModel.QuantidadeAplicada; ;
            aplicacaoItem.DataUpdate = DateTime.Now;


            await _aplicacaoItemService.Update(_mapper.Map<AplicacaoItem>(aplicacaoItem));

            return CustomReponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<AplicacaoItemViewModel>> Deletar(Guid id)
        {
            var produto = ObterAplicacaoItem(id);

            if (produto == null) return CustomReponse(HttpStatusCode.NoContent);

            await _aplicacaoItemService.Delete(id);

            return CustomReponse(HttpStatusCode.NoContent);
        }

        private async Task<AplicacaoItemViewModel> ObterAplicacaoItem(Guid id)
        {
            return _mapper.Map<AplicacaoItemViewModel>(await _aplicacaoItemRepository.BuscarPorId(id));
        }

        private async Task ValidaPostAplicacaoItem(AplicacaoItemViewModel aplicacaoItemViewModel)
        {
            if (!await _produtoRepository.ProdutoExiste(aplicacaoItemViewModel.ProdutoId))
                NotificarErro("Produto não encontrado");
        }
    }
}
