using Medicar.Application.Dtos.SpecialtyDtos;
using Medicar.Domain.Return;

namespace Medicar.Application.Interfaces;

public interface ISpecialtyService
{
    Task<CustomReturn<SpecialtyDto>> GetAll();
    Task<CustomReturn<SpecialtyDto>> GetById(int id);
    Task<CustomReturn<SpecialtyDto>> Add(PostSpecialtyDto specialty);
    Task<CustomReturn<SpecialtyDto>> Update(SpecialtyDto specialty);
    Task<CustomReturn<SpecialtyDto>> Delete(int id);
}
