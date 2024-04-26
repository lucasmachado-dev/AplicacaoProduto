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
    public class AplicacaoItemRepository : Repository<AplicacaoItem>, IAplicacaoItemRepository
    {
        public AplicacaoItemRepository(appDbContext db) : base(db)
        {
        }
    }
}
