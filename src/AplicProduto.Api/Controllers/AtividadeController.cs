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
    [Route("api/atividades")]
    public class AtividadeController:MainController
    {
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IAtividadeService _atividadeService;
        private readonly IMapper _mapper;

        public AtividadeController(IAtividadeRepository atividadeRepository, 
                                   IAtividadeService atividadeService, 
                                   IMapper mapper,
                                   INotificador notificador) : base(notificador)
        {
            _atividadeRepository = atividadeRepository;
            _atividadeService = atividadeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AtividadeViewModel>> ObterAtividades()
        {
            return _mapper.Map<IEnumerable<AtividadeViewModel>>(await _atividadeRepository.BuscarTodos());

        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<AtividadeViewModel>> ObterAtividadePorId(Guid id)
        {
            var produto = _mapper.Map<AtividadeViewModel>(await _atividadeRepository.BuscarPorId(id));

            if (produto == null) return NotFound();

            return produto;
        }

        [HttpPost]
        public async Task<ActionResult<AtividadeViewModel>> Adicionar(AtividadeViewModel atividadeViewModel)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            await _atividadeService.Create(_mapper.Map<Atividade>(atividadeViewModel));

            return CustomReponse(HttpStatusCode.Created, atividadeViewModel);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<AtividadeViewModel>> Atualizar(AtividadeViewModel atividadeViewModel, Guid id)
        {
            if (atividadeViewModel.Id != id)
            {
                NotificarErro("Os ids informados não são iguais");
                return CustomReponse();
            }

            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var atividade = await ObterAtividade(id);

            atividade.TipoAtividade = atividadeViewModel.TipoAtividade;
            atividade.Descricao = atividadeViewModel.Descricao;
            atividade.DataUpdate = DateTime.Now;


            await _atividadeService.Update(_mapper.Map<Atividade>(atividade));

            return CustomReponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<AtividadeViewModel>> Deletar(Guid id)
        {
            var produto = ObterAtividade(id);

            if (produto == null) return CustomReponse(HttpStatusCode.NoContent);

            await _atividadeService.Delete(id);

            return CustomReponse(HttpStatusCode.NoContent);
        }

        private async Task<AtividadeViewModel> ObterAtividade(Guid id)
        {
            return _mapper.Map<AtividadeViewModel>(await _atividadeRepository.BuscarPorId(id));
        }
    }
}
