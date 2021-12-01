using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserManagement.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void Delete(int id);

        void Dispose();
    }
}
