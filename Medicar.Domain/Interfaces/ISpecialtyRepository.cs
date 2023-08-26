using Medicar_API.Domain.Entities;

namespace Medicar.Domain.Interfaces;

public interface ISpecialtyRepository
{
    Task<List<Specialty>> GetAllSpecialty();
    Task<Specialty> GetSpecialtyById(int id);
    Task<Specialty> CreateSpecialty(Specialty specialty);
    Task<Specialty> UpdateSpecialty(Specialty specialty);
    Task DeleteSpecialty(Specialty specialty);
}
