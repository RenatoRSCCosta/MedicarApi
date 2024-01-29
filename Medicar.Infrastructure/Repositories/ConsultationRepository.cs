using Medicar.Domain.Interfaces;
using Medicar.Infrastructure.Contexs;
using Medicar_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medicar.Infrastructure.Repositories;

public class ConsultationRepository : IConsultationRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ConsultationRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<Consultation>> GetAll()
    {
        return await _dbContext.Consultations.ToListAsync();
    }

    public async Task<Consultation?> GetById(int id)
    {
        return await _dbContext.Consultations.FindAsync(id);
    }

    public async Task<Consultation?> Add(Consultation consultation)
    {
        _dbContext.Consultations.Add(consultation);

        await _dbContext.SaveChangesAsync();

        return await GetById(consultation.ConsultationId);
    }

    public async Task<Consultation?> Update(Consultation consultation)
    {
        _dbContext.Consultations.Update(consultation);

        await _dbContext.SaveChangesAsync();

        return await GetById(consultation.ConsultationId);
    }

    public async Task Delete(Consultation consultation)
    {
        _dbContext.Consultations.Remove(consultation);

        await _dbContext.SaveChangesAsync();
    }
}
