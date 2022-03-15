using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BotBlazorApp.Data.Repositories;

public class GenericRepository<TEntity> where TEntity : class
{
    private readonly SqlDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(SqlDbContext context)
    {
        this._context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual Task<List<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null) query = query.Where(filter);

        foreach (var includeProperty in includeProperties.Split
                     (new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            query = query.Include(includeProperty);

        if (orderBy != null)
            return orderBy(query).ToListAsync();
        return query.ToListAsync();
    }

    public virtual TEntity? GetByID(int id)
    {
        return _dbSet.Find(id);
    }

    public virtual void Insert(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Delete(int id)
    {
        var entityToDelete = _dbSet.Find(id);
        if (entityToDelete != null) 
            Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (_context.Entry(entityToDelete).State == EntityState.Detached) _dbSet.Attach(entityToDelete);
        _dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        _dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}