using Ardalis.Specification;
using IAM.Core.Entities;

namespace IAM.Core.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
        Task<T> AddAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);

        T Add(T entity, bool saveChanges = true);
        void Update(T entity, bool saveChanges = true);
        void Delete(T entity, bool saveChanges = true);
    }
}
