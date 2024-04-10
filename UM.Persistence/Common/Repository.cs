using Ardalis.Specification.EntityFrameworkCore;
using UM.Persistence.DbContexts;

namespace UM.Persistence.Common
{
    public class Repository<T>(UserManagementDbContext dbContext)
        : RepositoryBase<T>(dbContext), IRepository<T> where T : class
    {
    }
}