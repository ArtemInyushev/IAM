using Ardalis.Specification;
using IAM.Core.Entities;

namespace IAM.Core.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}
