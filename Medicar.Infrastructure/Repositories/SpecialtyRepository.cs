using Medicar.Domain.Interfaces;
using Medicar.Infrastructure.Contexs;
using Medicar_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medicar.Infrastructure.Repositories;

public class SpecialtyRepository : ISpecialtyRepository
{
    private readonly ApplicationDbContext _dbContext;
    public SpecialtyRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public Task<List<Specialty>> GetAll()
    {
        return _dbContext.Specialtys.ToListAsync();
    }

    public async Task<Specialty?> GetById(int id)
    {
        return await _dbContext.Specialtys.FindAsync(id);
    }
    public async Task<Specialty?> Add(Specialty specialty)
    {
        _dbContext.Specialtys.Add(specialty);

        await _dbContext.SaveChangesAsync();

        return await GetById(specialty.Id);
    }

    public async Task<Specialty?> Update(Specialty specialty)
    {
        _dbContext.Specialtys.Update(specialty);

        await _dbContext.SaveChangesAsync();

        return await GetById(specialty.Id);
    }

    public async Task Delete(Specialty specialty)
    {
        _dbContext.Specialtys.Remove(specialty);

        await _dbContext.SaveChangesAsync();
    }
}
