﻿using Microsoft.EntityFrameworkCore;
using Specification.Core.Application.Persistences;
using Specification.Core.Application.Specification;
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

    public async Task<Circle> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        var circle = await _dbContext.Circles.Include(e=>e.Users).FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (circle == null)
            throw new ArgumentNullException(nameof(Circle));
        return circle;
    }

    public async Task<IEnumerable<Circle>> GetRecommendCircle(Specification<Circle> specification)
    {
        var circles = await Task.Run(() => _dbContext.Circles.Where(specification.IsSatisfiedBy).Take(10).ToList());
        return circles;
    }

    public async Task<Circle> UpdateAsync(Circle entity, CancellationToken cancellationToken = default)
    {
        var result = _dbContext.Circles.Update(entity).Entity;
        await _dbContext.SaveChangesAsync();
        return result;
    }
}
