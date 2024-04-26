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
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(appDbContext db) : base(db) { }

        public async Task<bool> ProdutoExiste(Guid id)
        {
            var produto = await BuscarPorId(id);
            return produto != null;
        }

        public async Task<decimal> ValorProduto(Guid id)
        {
            var produto = await BuscarPorId(id);
            return produto.ValorProduto;
        }
    }
}
