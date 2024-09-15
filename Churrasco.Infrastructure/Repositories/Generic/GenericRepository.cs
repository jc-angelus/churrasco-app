using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Churrasco.Infrastructure.Repositories.Interfaces.Generic;

namespace Churrasco.Infrastructure.Repositories.Generic
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Class: GenericRepository
    /// </summary
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<T> CreateAsync(T model)
        {
         
            try
            {
                _unitOfWork.Context.Set<T>().Add(model);
                await _unitOfWork.Context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<T> ReadAsync(uint id)
        {
            try
            {
                return await _unitOfWork.Context.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public T? ReadByConditionAsync(Expression<Func<T, bool>> whereCondition = null)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>().AsQueryable();

            try
            {
                if (whereCondition != null)
                {
                    query = query.Where(whereCondition);
                }
                else
                {
                    return null;
                }

                return query.First();
            }
            catch (Exception)
            {

                return null;
            }

        }

        public virtual async Task<T> UpdateAsync(T model, object key)
        {
            if (model == null)
                return null;

            try
            {
                T exist = await _unitOfWork.Context.Set<T>().FindAsync(key);

                if (exist != null)
                {
                    _unitOfWork.Context.Entry(exist).CurrentValues.SetValues(model);
                    await _unitOfWork.Context.SaveChangesAsync();
                }

                return exist;
            }
            catch (Exception)
            {
                throw;
            }


        }

        public virtual async Task<bool> DeleteAsync(object key)
        {
            try
            {

                T entity = await _unitOfWork.Context.Set<T>().FindAsync(key);

                if (entity != null)
                {
                    _unitOfWork.Context.Set<T>().Remove(entity);
                    await _unitOfWork.Context.SaveChangesAsync();
                   
                }

                return true;

            }
            catch (Exception)
            {
                throw;

            }            
        }
        public async Task<IEnumerable<T>> ListAsync()
        {

            try
            {
                IEnumerable<T> query = await _unitOfWork.Context.Set<T>().ToListAsync();

                return query;

            }
            catch (Exception)
            {
                throw;
            }           

        }

    }
}
