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
    [Route("api/fazendas")]
    public class FazendaController : MainController
    {
        private readonly IFazendaRepository _fazendaRepository;
        private readonly IFazendaService _fazendaService;
        private readonly IMapper _mapper;

        public FazendaController(IFazendaRepository fazendaRepository,
                                 IFazendaService fazendaService, 
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _fazendaRepository = fazendaRepository;
            _fazendaService = fazendaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FazendaViewModel>> ObterFazendas()
        {
            return _mapper.Map<IEnumerable<FazendaViewModel>>(await _fazendaRepository.BuscarTodos());

        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<FazendaViewModel>> ObterFazendaPorId(Guid id)
        {
            var produto = _mapper.Map<FazendaViewModel>(await _fazendaRepository.BuscarPorId(id));

            if (produto == null) return NotFound();

            return produto;
        }

        [HttpPost]
        public async Task<ActionResult<FazendaViewModel>> Adicionar(FazendaViewModel fazendaViewModel)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            await _fazendaService.Create(_mapper.Map<Fazenda>(fazendaViewModel));

            return CustomReponse(HttpStatusCode.Created, fazendaViewModel);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<FazendaViewModel>> Atualizar(FazendaViewModel fazendaViewModel, Guid id)
        {
            if (fazendaViewModel.Id != id)
            {
                NotificarErro("Os ids informados não são iguais");
                return CustomReponse();
            }

            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var fazenda = await ObterFazenda(id);

            fazenda.Descricao = fazendaViewModel.Descricao;

            await _fazendaService.Update(_mapper.Map<Fazenda>(fazenda));

            return CustomReponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<FazendaViewModel>> Deletar(Guid id)
        {
            var produto = ObterFazenda(id);

            if (produto == null) return CustomReponse(HttpStatusCode.NoContent);

            await _fazendaService.Delete(id);

            return CustomReponse(HttpStatusCode.NoContent);
        }

        private async Task<FazendaViewModel> ObterFazenda(Guid id)
        {
            return _mapper.Map<FazendaViewModel>(await _fazendaRepository.BuscarPorId(id));
        }
    }
}
