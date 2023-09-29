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

    public async Task<Consultation> CreateConsultation(Consultation consultation)
    {
        _dbContext.Consultations.Add(consultation);
        await _dbContext.SaveChangesAsync();
        return slot;
    }

    public async Task DeleteConsultation(Consultation consultation)
    {
        _dbContext.Consultations.Remove(consultation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Consultation>> GetAllConsultations()
    {
        return await _dbContext.Consultations.ToListAsync();
    }

    public async Task<Consultation> GetConsultationById(int id)
    {
        return await _dbContext.Consultations.FindAsync(id);
    }

    public async Task<Consultation> UpdateConsultation(Consultation consultation)
    {
        _dbContext.Consultations.Update(consultation);
        await _dbContext.SaveChangesAsync();
        return await GetConsultationById(consultation.ConsultationId);
    }
}
