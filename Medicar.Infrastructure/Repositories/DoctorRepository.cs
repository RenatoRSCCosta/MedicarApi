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

    public async Task<Doctor> CreateDoctor(Doctor doctor)
    {
        _dbContext.Doctors.Add(doctor);
        await _dbContext.SaveChangesAsync();
        return doctor;
    }

    public async Task DeleteDoctor(Doctor doctor)
    {
        _dbContext.Doctors.Remove(doctor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Doctor>> GetAllDoctors()
    {
        return await _dbContext.Doctors
            .Include(d => d.Specialty)
            .ToListAsync();
    }

    public async Task<Doctor> GetDoctorById(int id)
    {
        return await _dbContext.Doctors
            .Include(d => d.Specialty)
            .FirstOrDefaultAsync(d => d.DoctorId == id);
    }

    public async Task<Doctor> UpdateDoctor(Doctor doctor)
    {
        _dbContext.Doctors.Update(doctor);
        await _dbContext.SaveChangesAsync();
        return await GetDoctorById(doctor.DoctorId);
    }
}
