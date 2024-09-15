using System.Linq.Expressions;

namespace Churrasco.Infrastructure.Repositories.Interfaces.Generic
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Interface: IGenericRepository
    /// </summary
    public interface IGenericRepository<T> where T : class
    {        
        Task<T> CreateAsync(T entity);
        Task<T> ReadAsync(uint id);
        T? ReadByConditionAsync(Expression<Func<T, bool>> whereCondition = null);
        Task<T> UpdateAsync(T entity, object key);
        Task<bool> DeleteAsync(object key);
        Task<IEnumerable<T>> ListAsync();
    }


}
