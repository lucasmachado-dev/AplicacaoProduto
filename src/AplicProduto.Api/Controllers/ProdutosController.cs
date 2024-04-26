using AplicProduto.Api.ViewModels;
using AplicProduto.Business.Interfaces;
using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Interfaces.Services;
using AplicProduto.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AplicProduto.Api.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository, 
                                  IProdutoService produtoService, 
                                  IMapper mapper,
                                  INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterProdutos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.BuscarTodos());

        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterProdutoPorId(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.BuscarPorId(id));

            if (produto == null) return NotFound();

            return produto;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            await _produtoService.Create(_mapper.Map<Produto>(produtoViewModel));

            return CustomReponse(HttpStatusCode.Created, produtoViewModel);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Atualizar(ProdutoViewModel produtoViewModel, Guid id)
        {
            if (produtoViewModel.Id != id)
            {
                NotificarErro("Os ids informados não são iguais");
                return CustomReponse();
            }

            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var produto = await ObterProduto(id);

            produto.Descricao = produtoViewModel.Descricao;
            produto.ValorProduto = produtoViewModel.ValorProduto;
            produto.DataUpdate = DateTime.Now;

            await _produtoService.Update(_mapper.Map<Produto>(produto));

            return CustomReponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Deletar(Guid id)
        {
            var produto = ObterProduto(id);

            if (produto == null) return CustomReponse(HttpStatusCode.NoContent);
            
            await _produtoService.Delete(id);

            return CustomReponse(HttpStatusCode.NoContent);
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.BuscarPorId(id));
        }
    }
}
