using CtasPagarAPI.Models;

namespace CtasPagarAPI.Repositories
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext repositoryContext)
             : base(repositoryContext)
        {
        }
    }
}
