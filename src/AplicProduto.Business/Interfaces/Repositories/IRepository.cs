using AplicProduto.Business.Models;
using System.Linq.Expressions;

namespace AplicProduto.Business.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> BuscarPorId(Guid id);
        Task<IEnumerable<TEntity>> BuscarTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
