using Microsoft.EntityFrameworkCore;
using Specification.Core.Application.Persistences;
using Specification.Core.Domain.Entity;

namespace Specification.Infrastructure.Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<User> CreateAsync(User entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> FindAllAsync(IEnumerable<long> ids, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.OrderBy(_ => _.Id).ToListAsync();
    }

    public Task<User> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
