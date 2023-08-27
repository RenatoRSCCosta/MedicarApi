using AutoMapper;
using Medicar.Application.Dtos;
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

    public async Task<List<SpecialtyDto>> GetAllSpecialtys()
    {
        var specialtys = await _repositoryUoW.Specialtys.GetAllSpecialtys();
        return _mapper.Map<List<SpecialtyDto>>(specialtys);
    }

    public async Task<SpecialtyDto> GetSpecialtyById(int id)
    {
        var specialty = await _repositoryUoW.Specialtys.GetSpecialtyById(id);
        return _mapper.Map<SpecialtyDto>(specialty);
    }

    public async Task<SpecialtyDto> CreateSpecialty(SpecialtyDto specialtyDto)
    {
        var specialty = _mapper.Map<Specialty>(specialtyDto);
        var result = await _repositoryUoW.Specialtys.CreateSpecialty(specialty);
        return _mapper.Map<SpecialtyDto>(result);
    }

    public async Task<SpecialtyDto> UpdateSpecialty(SpecialtyDto specialtyDto)
    {
        var specialty = _mapper.Map<Specialty>(specialtyDto);
        var result = await _repositoryUoW.Specialtys.UpdateSpecialty(specialty);
        return _mapper.Map<SpecialtyDto>(result);
    }

    public async Task DeleteSpecialtyById(int id)
    {
        var specialty = await _repositoryUoW.Specialtys.GetSpecialtyById(id);
        await _repositoryUoW.Specialtys.DeleteSpecialty(specialty);
    }
}
