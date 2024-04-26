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
    [Route("api/ciclos-producao")]
    public class CicloProducaoController:MainController
    {
        private readonly ICicloProducaoRepository _cicloProducaoRepository;
        private readonly ICicloProducaoService _cicloProducaoService;
        private readonly IMapper _mapper;

        public CicloProducaoController(ICicloProducaoRepository repository, 
                                       ICicloProducaoService service, 
                                       IMapper mapper,
                                       INotificador notificador) : base(notificador)
        {
            _cicloProducaoRepository = repository;
            _cicloProducaoService = service;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<CicloProducaoViewModel>> ObterCiclosProducao()
        {
            return _mapper.Map<IEnumerable<CicloProducaoViewModel>>(await _cicloProducaoRepository.BuscarTodos());

        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<CicloProducaoViewModel>> ObterCicloProducaoPorId(Guid id)
        {
            var produto = _mapper.Map<CicloProducaoViewModel>(await _cicloProducaoRepository.BuscarPorId(id));

            if (produto == null) return NotFound();

            return produto;
        }


        [HttpPost]
        public async Task<ActionResult<CicloProducaoViewModel>> Adicionar(CicloProducaoViewModel cicloProducaoViewModel)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            await _cicloProducaoService.Create(_mapper.Map<CicloProducao>(cicloProducaoViewModel));

            return CustomReponse(HttpStatusCode.Created, cicloProducaoViewModel);
        }


        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<CicloProducaoViewModel>> Atualizar(CicloProducaoViewModel cicloProducaoViewModel, Guid id)
        {
            if (cicloProducaoViewModel.Id != id)
            {
                NotificarErro("Os ids informados não são iguais");
                return CustomReponse();
            }

            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var ciclo = await ObterCicloProducao(id);

            ciclo.Descricao = cicloProducaoViewModel.Descricao;
            ciclo.DataInicio = cicloProducaoViewModel.DataInicio;
            ciclo.DataFim = cicloProducaoViewModel.DataFim;
            ciclo.DataUpdate = DateTime.Now;


            await _cicloProducaoService.Update(_mapper.Map<CicloProducao>(ciclo));

            return CustomReponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<CicloProducaoViewModel>> Deletar(Guid id)
        {
            var talhao = ObterCicloProducao(id);

            if (talhao == null) return CustomReponse(HttpStatusCode.NoContent);

            await _cicloProducaoService.Delete(id);

            return CustomReponse(HttpStatusCode.NoContent);
        }

        private async Task<CicloProducaoViewModel> ObterCicloProducao(Guid id)
        {
            return _mapper.Map<CicloProducaoViewModel>(await _cicloProducaoRepository.BuscarPorId(id));
        }
    }
}
