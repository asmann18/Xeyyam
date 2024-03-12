using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Xeyyam.DAL;
using Xeyyam.Models;
using Xeyyam.Repositories.Abstract.Generic;

namespace Xeyyam.Repositories.Concrete.Generic;

public class Repository<T> : IRepository<T> where T :BaseEntity,  new()
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> GetAll()
    {
        var query=_context.Set<T>().AsQueryable();
        return query;
    }

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> expression)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(expression);
        return entity;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}
