using Medicar.Application.Dtos;
using Medicar.Application.Dtos.GetDtos;
using Medicar.Application.Dtos.PostDtos;
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
    Task<CustomReturn<GetSpecialtyDto>> GetAllSpecialtys();
    Task<CustomReturn<GetSpecialtyDto>> GetSpecialtyById(int id);
    Task<CustomReturn<PostSpecialtyDto>> CreateSpecialty(PostSpecialtyDto specialty);
    Task<CustomReturn<PutSpecialtyDto>> UpdateSpecialty(PutSpecialtyDto specialty);
    Task<CustomReturn<GetSpecialtyDto>> DeleteSpecialtyById(int id);
}
