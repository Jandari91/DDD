using Microsoft.EntityFrameworkCore;
using Specification.Core.Application.Persistences;
using Specification.Core.Domain.Entity;

namespace Specification.Infrastructure.Persistence.Repository;

public class CircleRepository : ICircleRepository
{
    private readonly ApplicationDbContext _dbContext;
    public CircleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Circle> CreateAsync(Circle entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Circle>> FindAllAsync(IEnumerable<long> ids, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Circle>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Circles.Include(e=>e.Users).OrderBy(_ => _.Id).ToListAsync();
    }

    public Task<Circle> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Circle> UpdateAsync(Circle entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
