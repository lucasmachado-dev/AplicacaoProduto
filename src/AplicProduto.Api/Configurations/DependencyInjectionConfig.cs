using AplicProduto.Business.Interfaces;
using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Interfaces.Services;
using AplicProduto.Business.Notificacoes;
using AplicProduto.Business.Services;
using AplicProduto.Data.Context;
using AplicProduto.Data.Repository;

namespace AplicProduto.Api.Configurations
{
    static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAplicacaoRepository, AplicacaoRepository>();
            services.AddScoped<IAplicacaoItemRepository, AplicacaoItemRepository>();
            services.AddScoped<IAtividadeRepository, AtividadeRepository>();
            services.AddScoped<ICicloProducaoRepository, CicloProducaoRepository>();
            services.AddScoped<ICulturaRepository, CulturaRepository>();
            services.AddScoped<IFazendaRepository, FazendaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ISafraRepository, SafraRepository>();
            services.AddScoped<ITalhaoRepository, TalhaoRepository>();


            services.AddScoped<IAplicacaoService, AplicacaoService>();
            services.AddScoped<IAplicacaoItemService, AplicacaoItemService>();
            services.AddScoped<IAtividadeService, AtividadeService>();
            services.AddScoped<ICicloProducaoService, CicloProducaoService>();
            services.AddScoped<ICulturaService, CulturaService>();
            services.AddScoped<IFazendaService, FazendaService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ISafraService, SafraService>();
            services.AddScoped<ITalhaoService, TalhaoService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
