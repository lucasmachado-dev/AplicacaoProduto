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
    public class TalhaoRepository : Repository<Talhao>, ITalhaoRepository
    {
        public TalhaoRepository(appDbContext db) : base(db) { }

        public async Task<bool> ExiteTalhao(Guid idTalhao)
        {
            var talhao = await BuscarPorId(idTalhao);
            return talhao != null;
        }

        public async Task<Guid> FazendaDoTalhao(Guid Id)
        {
            var talhao = await BuscarPorId(Id);
            return talhao.FazendaId;
        }
    }
}
