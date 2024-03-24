using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;
internal class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public readonly HRDatabaseContext _context;

    public GenericRepository(HRDatabaseContext context)
    {
        _context = context;
    }

    public async Task Create(T entity, CancellationToken cancellationToken)
    {
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(T entity, CancellationToken cancellationToken)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T> GetById(int id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task Update(T entity, CancellationToken cancellationToken)
    {
        //_context.Update(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
    }
}
