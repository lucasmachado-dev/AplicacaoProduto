using AplicProduto.Api.ViewModels;
using AplicProduto.Business.Models;
using AutoMapper;

namespace AplicProduto.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Aplicacao, AplicacaoViewModel>().ReverseMap();
            CreateMap<AplicacaoItem, AplicacaoItemViewModel>().ReverseMap();
            CreateMap<Atividade, AtividadeViewModel>().ReverseMap();
            CreateMap<CicloProducao, CicloProducaoViewModel>().ReverseMap();
            CreateMap<Cultura, CulturaViewModel>().ReverseMap();
            CreateMap<Fazenda, FazendaViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Safra, SafraViewModel>().ReverseMap();
            CreateMap<Talhao, TalhaoViewModel>().ReverseMap();
        }
    }
}
