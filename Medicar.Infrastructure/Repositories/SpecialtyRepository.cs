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
    public async Task<Specialty> CreateSpecialty(Specialty specialty)
    {
        _dbContext.Specialtys.Add(specialty);
        await _dbContext.SaveChangesAsync();
        return await GetSpecialtyById(specialty.SpecialtyId);
    }

    public async Task DeleteSpecialty(Specialty specialty)
    {
        _dbContext.Specialtys.Remove(specialty);
        await _dbContext.SaveChangesAsync();
    }

    public Task<List<Specialty>> GetAllSpecialtys()
    {
        return _dbContext.Specialtys.ToListAsync();
    }

    public async Task<Specialty> GetSpecialtyById(int id)
    {
        return await _dbContext.Specialtys.FindAsync(id);
    }

    public async Task<Specialty> UpdateSpecialty(Specialty specialty)
    {
        _dbContext.Specialtys.Update(specialty);
        await _dbContext.SaveChangesAsync();
        return await GetSpecialtyById(specialty.SpecialtyId);
    }
}
