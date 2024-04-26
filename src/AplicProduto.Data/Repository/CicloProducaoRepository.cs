using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Models;
using AplicProduto.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicProduto.Data.Repository
{
    public class CicloProducaoRepository : Repository<CicloProducao>, ICicloProducaoRepository
    {
        public CicloProducaoRepository(appDbContext db) : base(db) { }

        public async Task<Guid> CulturaDoCiclo(Guid Id)
        {
            var ciclo = await BuscarPorId(Id);
            return ciclo.CulturaId;
        }

        public async Task<bool> ExisteCiclo(Guid Id)
        {
            var ciclo = await BuscarPorId(Id);
            return ciclo != null;
        }
    }
}
