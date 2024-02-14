using Microsoft.EntityFrameworkCore;
using Application.Persistences;
using Domain.Entity;

namespace Infrastructure.EFCore.Repository;

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

    public async Task<User> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.Include(e => e.Circles).FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (user == null)
            throw new ArgumentNullException(nameof(Circle));
        return user;
    }

    public async Task<User> UpdateAsync(User entity, CancellationToken cancellationToken = default)
    {
        var result = _dbContext.Users.Update(entity).Entity;
        await _dbContext.SaveChangesAsync();
        return result;
    }
}
