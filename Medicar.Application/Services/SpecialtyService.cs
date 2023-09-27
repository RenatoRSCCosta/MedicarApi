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
    private ISpecialtyRepository _specialtyRepository;
    private IMapper _mapper;

    public SpecialtyService(ISpecialtyRepository specialtyRepository, IMapper mapper)
    {
        _specialtyRepository = specialtyRepository;
        _mapper = mapper;

    }

    public async Task<List<GetSpecialtyDto>> GetAllSpecialtys()
    {
        var specialtys = await _specialtyRepository.GetAllSpecialtys();
        return _mapper.Map<List<GetSpecialtyDto>>(specialtys);
    }

    public async Task<GetSpecialtyDto> GetSpecialtyById(int id)
    {
        var specialty = await _specialtyRepository.GetSpecialtyById(id);
        return _mapper.Map<GetSpecialtyDto>(specialty);
    }

    public async Task<PostSpecialtyDto> CreateSpecialty(PostSpecialtyDto specialtyDto)
    {
        var specialty = _mapper.Map<Specialty>(specialtyDto);
        var result = await _specialtyRepository.CreateSpecialty(specialty);
        return _mapper.Map<PostSpecialtyDto>(result);
    }

    public async Task<PutSpecialtyDto> UpdateSpecialty(PutSpecialtyDto specialtyDto)
    {
        var specialty = _mapper.Map<Specialty>(specialtyDto);
        var result = await _specialtyRepository.UpdateSpecialty(specialty);
        return _mapper.Map<PutSpecialtyDto>(result);
    }

    public async Task DeleteSpecialtyById(int id)
    {
        var specialty = await _specialtyRepository.GetSpecialtyById(id);
        await _specialtyRepository.DeleteSpecialty(specialty);
    }
}
