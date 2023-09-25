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

public class DoctorService : IDoctorService
{
    private IRepositoryUoW _repositoryUoW;
    private IMapper _mapper;

    public DoctorService(IRepositoryUoW repositoryUoW, IMapper mapper)
    {
        _repositoryUoW = repositoryUoW;
        _mapper = mapper;

    }

    public async Task<List<GetDoctorDto>> GetAllDoctors()
    {
        var doctors = await _repositoryUoW.Doctors.GetAllDoctors();
        if (doctors.Any())
        {
            foreach (var doctor in doctors)
            {
                doctor.Specialty = await _repositoryUoW.Specialtys.GetSpecialtyById(doctor.SpecialtyId);
            }
        }
        return _mapper.Map<List<GetDoctorDto>>(doctors);
    }

    public async Task<GetDoctorDto> GetDoctorById(int id)
    {
        var doctor = await _repositoryUoW.Doctors.GetDoctorById(id);
        if(doctor is not null)
        {
            doctor.Specialty = await _repositoryUoW.Specialtys.GetSpecialtyById(doctor.SpecialtyId);
        }
        return _mapper.Map<GetDoctorDto>(doctor);
    }

    public async Task<PostDoctorDto> CreateDoctor(PostDoctorDto doctorDto)
    {
        var doctor = _mapper.Map<Doctor>(doctorDto);
        var result = await _repositoryUoW.Doctors.CreateDoctor(doctor);
        return _mapper.Map<PostDoctorDto>(result);
    }

    public async Task<PutDoctorDto> UpdateDoctor(PutDoctorDto doctorDto)
    {
        var doctor = _mapper.Map<Specialty>(doctorDto);
        var result = await _repositoryUoW.Specialtys.UpdateSpecialty(doctor);
        return _mapper.Map<PutDoctorDto>(result);
    }

    public async Task DeleteDoctor(int id)
    {
        var doctor = await _repositoryUoW.Doctors.GetDoctorById(id);
        await _repositoryUoW.Doctors.DeleteDoctor(doctor);
    }
}
