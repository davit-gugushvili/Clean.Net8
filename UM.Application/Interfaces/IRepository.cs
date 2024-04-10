using Ardalis.Specification;

namespace UM.Application.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T>, IReadRepositoryBase<T> where T : class
    {
    }
}
