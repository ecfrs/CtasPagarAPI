using CtasPagarAPI.Models;

namespace CtasPagarAPI.Repositories
{
    public class ContaRepository : GenericRepository<Conta>, IContaRepository
    {
        public ContaRepository(AppDbContext repositoryContext)
             : base(repositoryContext)
        {
        }
    }
}
