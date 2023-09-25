using Medicar.Application.Dtos;
using Medicar.Application.Dtos.GetDtos;
using Medicar.Application.Dtos.PostDtos;
using Medicar_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Interfaces;

public interface ISpecialtyService
{
    Task<List<GetSpecialtyDto>> GetAllSpecialtys();
    Task<GetSpecialtyDto> GetSpecialtyById(int id);
    Task<PostSpecialtyDto> CreateSpecialty(PostSpecialtyDto specialty);
    Task<PutSpecialtyDto> UpdateSpecialty(PutSpecialtyDto specialty);
    Task DeleteSpecialtyById(int id);
}
