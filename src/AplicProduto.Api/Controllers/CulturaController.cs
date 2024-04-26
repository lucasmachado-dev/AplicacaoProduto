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
    [Route("api/culturas")]
    public class CulturaController : MainController
    {
        private readonly ICulturaRepository _culturaRepository;
        private readonly ICulturaService _culturaService;
        private readonly IMapper _mapper;

        public CulturaController(ICulturaRepository culturaRepository,
                                 ICulturaService culturaService,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _culturaRepository = culturaRepository;
            _culturaService = culturaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CulturaViewModel>> ObterCulturas()
        {
            return _mapper.Map<IEnumerable<CulturaViewModel>>(await _culturaRepository.BuscarTodos());

        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<CulturaViewModel>> ObterCulturaPorId(Guid id)
        {
            var produto = _mapper.Map<CulturaViewModel>(await _culturaRepository.BuscarPorId(id));

            if (produto == null) return NotFound();

            return produto;
        }

        [HttpPost]
        public async Task<ActionResult<CulturaViewModel>> Adicionar(CulturaViewModel culturaViewModel)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            await _culturaService.Create(_mapper.Map<Cultura>(culturaViewModel));

            return CustomReponse(HttpStatusCode.Created, culturaViewModel);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<CulturaViewModel>> Atualizar(CulturaViewModel culturaViewModel, Guid id)
        {
            if (culturaViewModel.Id != id)
            {
                NotificarErro("Os ids informados não são iguais");
                return CustomReponse();
            }

            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var cultura = await ObterCultura(id);

            cultura.Descricao = culturaViewModel.Descricao;
            cultura.NomeCientifico = culturaViewModel.NomeCientifico;
            cultura.DataUpdate = DateTime.Now;
            

            await _culturaService.Update(_mapper.Map<Cultura>(cultura));

            return CustomReponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<CulturaViewModel>> Deletar(Guid id)
        {
            var produto = ObterCultura(id);

            if (produto == null) return CustomReponse(HttpStatusCode.NoContent);

            await _culturaService.Delete(id);

            return CustomReponse(HttpStatusCode.NoContent);
        }

        private async Task<CulturaViewModel> ObterCultura(Guid id)
        {
            return _mapper.Map<CulturaViewModel>(await _culturaRepository.BuscarPorId(id));
        }
    }
}
