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
    [Route("api/aplicacao")]
    public class AplicacaoController : MainController
    {
        private readonly IAplicacaoRepository _aplicacaoRepository;
        private readonly IAplicacaoService _aplicacaoService;
        private readonly ISafraRepository _safraRepository;
        private readonly IFazendaRepository _fazendaRepository;
        private readonly ITalhaoRepository _talhaoRepository;
        private readonly ICicloProducaoRepository _cicloProducaoRepository;
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IMapper _mapper;

        public AplicacaoController(IAplicacaoRepository aplicacaoRepository,
                                   IAplicacaoService aplicacaoService,
                                   IMapper mapper,
                                   INotificador notificador,
                                   ISafraRepository safraRepository,
                                   IFazendaRepository fazendaRepository,
                                   ITalhaoRepository talhaoRepository,
                                   ICicloProducaoRepository cicloProducaoRepository,
                                   IAtividadeRepository atividadeRepository) : base(notificador)
        {
            _aplicacaoRepository = aplicacaoRepository;
            _aplicacaoService = aplicacaoService;
            _mapper = mapper;
            _safraRepository = safraRepository;
            _fazendaRepository = fazendaRepository;
            _talhaoRepository = talhaoRepository;
            _cicloProducaoRepository = cicloProducaoRepository;
            _atividadeRepository = atividadeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<AplicacaoViewModel>> ObterAplicacoes()
        {
            return _mapper.Map<IEnumerable<AplicacaoViewModel>>(await _aplicacaoRepository.BuscarTodos());

        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<AplicacaoViewModel>> ObterAplicacaoPorId(Guid id)
        {
            var aplicacao = _mapper.Map<AplicacaoViewModel>(await _aplicacaoRepository.BuscarPorId(id));

            if (aplicacao == null) return NotFound();

            return aplicacao;
        }
        
        [HttpPost]
        public async Task<ActionResult<AplicacaoViewModel>> Adicionar(AplicacaoViewModel aplicacaoViewModel)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            await ValidaPostAplicacao(aplicacaoViewModel);

            await _aplicacaoService.Create(_mapper.Map<Aplicacao>(aplicacaoViewModel));

            return CustomReponse(HttpStatusCode.Created, aplicacaoViewModel);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<AplicacaoViewModel>> Atualizar(AplicacaoViewModel aplicacaoViewModel, Guid id)
        {
            if (aplicacaoViewModel.Id != id)
            {
                NotificarErro("Os ids informados não são iguais");
                return CustomReponse();
            }

            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var aplicacao = await ObterAplicacao(id);

            aplicacao.TalhaoId = aplicacaoViewModel.TalhaoId;
            aplicacao.CicloProducaoId = aplicacaoViewModel.CicloProducaoId;
            aplicacao.AtividadeId = aplicacaoViewModel.AtividadeId;
            aplicacao.DataInicio = aplicacaoViewModel.DataInicio;
            aplicacao.DataFinal= aplicacaoViewModel.DataFinal;
            aplicacao.DataUpdate = DateTime.Now;


            await _aplicacaoService.Update(_mapper.Map<Aplicacao>(aplicacao));

            return CustomReponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<AplicacaoViewModel>> Deletar(Guid id)
        {
            var aplicacao = await ObterAplicacao(id);

            if (aplicacao == null) return CustomReponse(HttpStatusCode.NoContent);

            await _aplicacaoService.Delete(id);

            return CustomReponse(HttpStatusCode.NoContent);
        }

        private async Task<AplicacaoViewModel> ObterAplicacao(Guid id)
        {
            return _mapper.Map<AplicacaoViewModel>(await _aplicacaoRepository.BuscarPorId(id));
        }

        private async Task ValidaPostAplicacao(AplicacaoViewModel aplicacaoViewModel)
        {
            if (!await _fazendaRepository.ExisteFazenda(aplicacaoViewModel.FazendaId))
                NotificarErro("Fazenda não encontrada");

            if (!await _safraRepository.SafraAtiva(aplicacaoViewModel.SafraId))
                NotificarErro("Safra não encontrada ou inativa");

            if (!await _talhaoRepository.ExiteTalhao(aplicacaoViewModel.TalhaoId))
                NotificarErro("Talhão não encontrado");

            if (!await _cicloProducaoRepository.ExisteCiclo(aplicacaoViewModel.CicloProducaoId))
                NotificarErro("Ciclo de Produção não encontrado");
            
            if (!await _atividadeRepository.ExisteAtividade(aplicacaoViewModel.AtividadeId))
                NotificarErro("Atividade não encontrada");

            var fazendaTalhao = await _talhaoRepository.FazendaDoTalhao(aplicacaoViewModel.TalhaoId);
            if (fazendaTalhao != aplicacaoViewModel.FazendaId)
                NotificarErro("Talhão não pertence à fazenda");

        }
    }
}
