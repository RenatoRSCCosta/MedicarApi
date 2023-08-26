using Medicar_API.Domain.Entities;

namespace Medicar.Domain.Interfaces;

public interface IDoctorRepository
{
    Task<List<Doctor>> GetAllDoctors();
    Task<Doctor> GetDoctorById(int id);
    Task<Doctor> CreateDoctor(Doctor doctor);
    Task<Doctor> UpdateDoctor(Doctor doctor);
    Task DeleteDoctor(Doctor doctor);
}
