using Medicar.Domain.Interfaces;
using Medicar.Infrastructure.Contexs;
using Medicar_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medicar.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _dbContext;
    public DoctorRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<Doctor>> GetAll()
    {
        return await _dbContext.Doctors.ToListAsync();
    }

    public async Task<Doctor?> GetById(int id)
    {
        return await _dbContext.Doctors.FindAsync(id);
    }

    public async Task<Doctor?> Add(Doctor doctor)
    {
        _dbContext.Doctors.Add(doctor);

        await _dbContext.SaveChangesAsync();

        return await GetById(doctor.DoctorId);
    }

    public async Task<Doctor?> Update(Doctor doctor)
    {
        _dbContext.Doctors.Update(doctor);

        await _dbContext.SaveChangesAsync();

        return await GetById(doctor.DoctorId);
    }

    public async Task Delete(Doctor doctor)
    {
        _dbContext.Doctors.Remove(doctor);

        await _dbContext.SaveChangesAsync();
    }
}
