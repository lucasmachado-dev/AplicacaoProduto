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
    [Route("api/talhoes")]
    public class TalhaoController:MainController
    {
        private readonly ITalhaoRepository _talhaoRepository;
        private readonly ITalhaoService _talhaoService;
        private readonly IMapper _mapper;

        public TalhaoController(ITalhaoRepository talhaoRepository, 
                                ITalhaoService talhaoService,  
                                IMapper mapper,
                                INotificador notificador) : base(notificador)
        {
            _talhaoRepository = talhaoRepository;
            _talhaoService = talhaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TalhaoViewModel>> ObterTalhoes()
        {
            return _mapper.Map<IEnumerable<TalhaoViewModel>>(await _talhaoRepository.BuscarTodos());

        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<TalhaoViewModel>> ObterTalhaoPorId(Guid id)
        {
            var produto = _mapper.Map<TalhaoViewModel>(await _talhaoRepository.BuscarPorId(id));

            if (produto == null) return NotFound();

            return produto;
        }

        [HttpPost]
        public async Task<ActionResult<TalhaoViewModel>> Adicionar(TalhaoViewModel talhaoViewModel)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            await _talhaoService.Create(_mapper.Map<Talhao>(talhaoViewModel));

            return CustomReponse(HttpStatusCode.Created, talhaoViewModel);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<TalhaoViewModel>> Atualizar(TalhaoViewModel talhaoViewModel, Guid id)
        {
            if (talhaoViewModel.Id != id)
            {
                NotificarErro("Os ids informados não são iguais");
                return CustomReponse();
            }

            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var talhao = await ObterTalhao(id);

            talhao.Identificacao = talhaoViewModel.Identificacao;
            talhao.Area = talhaoViewModel.Area;
            talhao.DataUpdate = DateTime.Now;


            await _talhaoService.Update(_mapper.Map<Talhao>(talhao));

            return CustomReponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<TalhaoViewModel>> Deletar(Guid id)
        {
            var talhao = ObterTalhao(id);

            if (talhao == null) return CustomReponse(HttpStatusCode.NoContent);

            await _talhaoService.Delete(id);

            return CustomReponse(HttpStatusCode.NoContent);
        }

        private async Task<TalhaoViewModel> ObterTalhao(Guid id)
        {
            return _mapper.Map<TalhaoViewModel>(await _talhaoRepository.BuscarPorId(id));
        }
    }
}
