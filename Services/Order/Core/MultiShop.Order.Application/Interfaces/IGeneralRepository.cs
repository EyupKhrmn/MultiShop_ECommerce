using System.Linq.Expressions;

namespace MultiShop.Order.Application.Interfaces;

public interface IGeneralRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
}