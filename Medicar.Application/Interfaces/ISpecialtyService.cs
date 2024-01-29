using Medicar.Application.Dtos;
using Medicar.Application.Dtos.SpecialtyDtos;
using Medicar.Domain.Return;
using Medicar_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Interfaces;

public interface ISpecialtyService
{
    Task<CustomReturn<SpecialtyDto>> GetAllSpecialtys();
    Task<CustomReturn<SpecialtyDto>> GetSpecialtyById(int id);
    Task<CustomReturn<PostSpecialtyDto>> CreateSpecialty(PostSpecialtyDto specialty);
    Task<CustomReturn<SpecialtyDto>> UpdateSpecialty(SpecialtyDto specialty);
    Task<CustomReturn<SpecialtyDto>> DeleteSpecialtyById(int id);
}
