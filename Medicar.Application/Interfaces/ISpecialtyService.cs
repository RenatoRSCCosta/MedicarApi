using Medicar.Application.Dtos;
using Medicar_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Interfaces;

public interface ISpecialtyService
{
    Task<List<SpecialtyDto>> GetAllSpecialtys();
    Task<SpecialtyDto> GetSpecialtyById(int id);
    Task<SpecialtyDto> CreateSpecialty(SpecialtyDto specialty);
    Task<SpecialtyDto> UpdateSpecialty(SpecialtyDto specialty);
    Task DeleteSpecialtyById(int id);
}
