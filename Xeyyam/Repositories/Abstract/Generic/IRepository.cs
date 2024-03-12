using System.Linq.Expressions;
using Xeyyam.Models;

namespace Xeyyam.Repositories.Abstract.Generic;

public interface IRepository<T> where T : BaseEntity, new()
{
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<int> SaveChangesAsync();

    IQueryable<T> GetAll();
    Task<T?> GetSingleAsync(Expression<Func<T, bool>> expression);
}
