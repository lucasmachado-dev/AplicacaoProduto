using AplicProduto.Business.Interfaces;
using AplicProduto.Business.Interfaces.Repositories;
using AplicProduto.Business.Interfaces.Services;
using AplicProduto.Business.Models;
using AplicProduto.Business.Models.Validations;

namespace AplicProduto.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task Create(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
            
            await _produtoRepository.Adicionar(produto);
        }
        public async Task Update(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Atualizar(produto);
        }

        public async Task Delete(Guid id)
        {
            await _produtoRepository.Remover(id);
        }
    }
}
