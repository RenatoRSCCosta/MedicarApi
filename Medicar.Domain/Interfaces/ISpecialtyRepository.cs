using Medicar_API.Domain.Entities;

namespace Medicar.Domain.Interfaces;

public interface ISpecialtyRepository
{
    Task<List<Specialty>> GetAll();

    Task<Specialty?> GetById(int id);

    Task<Specialty?> Add(Specialty specialty);

    Task<Specialty?> Update(Specialty specialty);

    Task Delete(Specialty specialty);
}
