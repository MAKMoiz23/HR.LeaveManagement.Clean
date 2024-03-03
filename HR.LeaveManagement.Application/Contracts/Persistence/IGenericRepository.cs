using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
    Task<T> GetById(int id, CancellationToken cancellationToken);
    Task Delete(T entity, CancellationToken cancellationToken);
    Task Update(T entity, CancellationToken cancellationToken);
    Task Create(T entity, CancellationToken cancellationToken);
}