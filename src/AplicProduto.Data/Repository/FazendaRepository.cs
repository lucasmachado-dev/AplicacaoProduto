using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Models;
using AplicProduto.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicProduto.Data.Repository
{
    public class FazendaRepository : Repository<Fazenda>, IFazendaRepository
    {
        public FazendaRepository(appDbContext db) : base(db) { }

        public async Task<bool> ExisteFazenda(Guid idFazenda)
        {
            var fazenda = await BuscarPorId(idFazenda);
            return fazenda != null;
        }

    }
}
