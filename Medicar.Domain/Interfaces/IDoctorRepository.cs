using Medicar_API.Domain.Entities;

namespace Medicar.Domain.Interfaces;

public interface IDoctorRepository
{
    Task<List<Doctor>> GetAll();

    Task<Doctor?> GetById(int id);

    Task<Doctor?> Add(Doctor doctor);

    Task<Doctor?> Update(Doctor doctor);

    Task Delete(Doctor doctor);
}
