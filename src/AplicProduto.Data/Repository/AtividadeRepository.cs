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
    public class AtividadeRepository : Repository<Atividade>, IAtividadeRepository
    {
        public AtividadeRepository(appDbContext db) :base(db) {}

        public async Task<bool> ExisteAtividade(Guid Id)
        {
            var atividade = await BuscarPorId(Id);
            return atividade != null;
        }
    }
}
