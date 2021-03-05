using System.Collections.Generic;
using System.Threading.Tasks;

namespace CtasPagarAPI.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T obj);
        Task Update(int id, T obj);
        Task Delete(int id);
    }
}
