using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Models;
using AplicProduto.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AplicProduto.Data.Repository
{
    public class AplicacaoRepository : Repository<Aplicacao>, IAplicacaoRepository
    {
        public AplicacaoRepository(appDbContext db) : base(db) { }

        public async Task<List<AplicacaoItem>> ObterItensAplicacao(Guid Id)
        {
            return await Db.AplicacaoItens
                .Where(x => x.AplicacaoId == Id)
                .ToListAsync();

        }

    }
}
