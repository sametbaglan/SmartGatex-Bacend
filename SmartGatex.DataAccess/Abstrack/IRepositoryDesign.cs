using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartGatex.DataAccess.Abstrack
{
    public interface IRepositoryDesign<T>
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
FindOptions<T, T> orderBy = null, string includeProperties = null);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter, FindOptions<T, T> orderBy = null);
        Task<T> AddAsync(T entity);
        bool Update(T entity, Expression<Func<T, bool>> filter);
    }
}
