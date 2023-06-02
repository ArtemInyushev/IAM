using Ardalis.Specification.EntityFrameworkCore;
using IAM.Core.Entities;
using IAM.Core.Interfaces;
using IAM.Infrastructure.Data;

namespace IAM.Infrastructure.Repositories
{
    public class IamRepository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
    {
        private readonly IamDbContext _dbContext;
        public IamRepository(IamDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T enity, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Add(enity);
            if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);
            return enity;
        }

        public async Task UpdateAsync(T enity, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Update(enity);
            if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T enity, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Remove(enity);
            if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual T Add(T enity, bool saveChanges = true)
        {
            _dbContext.Set<T>().Add(enity);
            if (saveChanges) _dbContext.SaveChanges();
            return enity;
        }

        public void Update(T enity, bool saveChanges = true)
        {
            _dbContext.Set<T>().Update(enity);
            if (saveChanges) _dbContext.SaveChanges();
        }

        public void Delete(T enity, bool saveChanges = true)
        {
            _dbContext.Set<T>().Remove(enity);
            if (saveChanges) _dbContext.SaveChanges();
        }
    }
}
