using AutoMapper;
using Medicar.Application.Dtos;
using Medicar.Application.Dtos.GetDtos;
using Medicar.Application.Dtos.PostDtos;
using Medicar.Application.Interfaces;
using Medicar.Domain.Interfaces;
using Medicar_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Services;

public class SpecialtyService : ISpecialtyService
{
    private IRepositoryUoW _repositoryUoW;
    private IMapper _mapper;

    public SpecialtyService(IRepositoryUoW repositoryUoW, IMapper mapper)
    {
        _repositoryUoW = repositoryUoW;
        _mapper = mapper;

    }

    public async Task<List<GetSpecialtyDto>> GetAllSpecialtys()
    {
        var specialtys = await _repositoryUoW.Specialtys.GetAllSpecialtys();
        return _mapper.Map<List<GetSpecialtyDto>>(specialtys);
    }

    public async Task<GetSpecialtyDto> GetSpecialtyById(int id)
    {
        var specialty = await _repositoryUoW.Specialtys.GetSpecialtyById(id);
        return _mapper.Map<GetSpecialtyDto>(specialty);
    }

    public async Task<PostSpecialtyDto> CreateSpecialty(PostSpecialtyDto specialtyDto)
    {
        var specialty = _mapper.Map<Specialty>(specialtyDto);
        var result = await _repositoryUoW.Specialtys.CreateSpecialty(specialty);
        return _mapper.Map<PostSpecialtyDto>(result);
    }

    public async Task<PutSpecialtyDto> UpdateSpecialty(PutSpecialtyDto specialtyDto)
    {
        var specialty = _mapper.Map<Specialty>(specialtyDto);
        var result = await _repositoryUoW.Specialtys.UpdateSpecialty(specialty);
        return _mapper.Map<PutSpecialtyDto>(result);
    }

    public async Task DeleteSpecialtyById(int id)
    {
        var specialty = await _repositoryUoW.Specialtys.GetSpecialtyById(id);
        await _repositoryUoW.Specialtys.DeleteSpecialty(specialty);
    }
}
