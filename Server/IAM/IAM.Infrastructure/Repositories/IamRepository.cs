using Ardalis.Specification.EntityFrameworkCore;
using IAM.Core.Entities;
using IAM.Core.Interfaces;
using IAM.Infrastructure.Data;

namespace IAM.Infrastructure.Repositories
{
    public class IamRepository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public IamRepository(IamDbContext dbContext) : base(dbContext)
        {
        }
    }
}
