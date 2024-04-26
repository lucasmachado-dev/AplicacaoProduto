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
    public class SafraRepository : Repository<Safra>, ISafraRepository
    {
        public SafraRepository(appDbContext db) : base(db) { }

        public async Task<bool> SafraAtiva(Guid id)
        {
            var safra = await BuscarPorId(id);
            return safra != null && safra.Ativo;
        }

        
    }
}
