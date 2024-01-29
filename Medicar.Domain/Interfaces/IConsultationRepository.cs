using Medicar_API.Domain.Entities;

namespace Medicar.Domain.Interfaces;

public interface IConsultationRepository
{
    Task<List<Consultation>> GetAll();

    Task<Consultation?> GetById(int id);

    Task<Consultation?> Add(Consultation consultation);

    Task<Consultation?> Update(Consultation consultation);

    Task Delete(Consultation consultation);
}
