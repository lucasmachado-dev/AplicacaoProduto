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
    [Route("api/safras")]
    public class SafraController : MainController
    {
        private readonly ISafraRepository _safraRepository;
        private readonly ISafraService _safraService;
        private readonly IMapper _mapper;

        public SafraController(ISafraRepository safraRepository,
                               ISafraService safraService,
                               IMapper mapper,
                               INotificador notificador) : base(notificador)
        {
            _safraRepository = safraRepository;
            _safraService = safraService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SafraViewModel>> ObterSafras()
        {
            return _mapper.Map<IEnumerable<SafraViewModel>>(await _safraRepository.BuscarTodos());

        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<SafraViewModel>> ObterSafraPorId(Guid id)
        {
            var safra = _mapper.Map<SafraViewModel>(await _safraRepository.BuscarPorId(id));

            if (safra == null) return NotFound();

            return safra;
        }

        [HttpPost]
        public async Task<ActionResult<SafraViewModel>> Adicionar(SafraViewModel safraViewModel)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            await _safraService.Create(_mapper.Map<Safra>(safraViewModel));

            return CustomReponse(HttpStatusCode.Created, safraViewModel);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<SafraViewModel>> Atualizar(SafraViewModel safraViewModel, Guid id)
        {
            if (safraViewModel.Id != id)
            {
                NotificarErro("Os ids informados não são iguais");
                return CustomReponse();
            }

            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var safra = await ObterSafra(id);

            safra.Descricao = safraViewModel.Descricao;
            safra.DataInicio = safraViewModel.DataInicio;
            safra.DataFim = safraViewModel.DataFim;
            safra.Ativo = safraViewModel.Ativo;
            safra.DataUpdate = DateTime.Now;

            await _safraService.Update(_mapper.Map<Safra>(safra));

            return CustomReponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<SafraViewModel>> Deletar(Guid id)
        {
            var safra = await ObterSafra(id);

            if (safra == null) return CustomReponse(HttpStatusCode.NotFound);

            await _safraService.Delete(id);

            return CustomReponse(HttpStatusCode.NoContent);
        }

        private async Task<SafraViewModel> ObterSafra(Guid id)
        {
            return _mapper.Map<SafraViewModel>(await _safraRepository.BuscarPorId(id));
        }

    }
}
