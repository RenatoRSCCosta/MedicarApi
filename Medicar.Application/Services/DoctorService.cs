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
    private IDoctorRepository _doctorRepository;
    private ISpecialtyRepository _specialtyRepository;
    private IMapper _mapper;

    public DoctorService(IDoctorRepository doctorRepository, ISpecialtyRepository specialtyRepository, IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _specialtyRepository = specialtyRepository;
        _mapper = mapper;

    }

    public async Task<List<GetDoctorDto>> GetAllDoctors()
    {
        var doctors = await _doctorRepository.GetAllDoctors();
        if (doctors.Any())
        {
            foreach (var doctor in doctors)
            {
                doctor.Specialty = await _specialtyRepository.GetSpecialtyById(doctor.SpecialtyId);
            }
        }
        return _mapper.Map<List<GetDoctorDto>>(doctors);
    }

    public async Task<GetDoctorDto> GetDoctorById(int id)
    {
        var doctor = await _doctorRepository.GetDoctorById(id);
        if(doctor is not null)
        {
            doctor.Specialty = await _specialtyRepository.GetSpecialtyById(doctor.SpecialtyId);
        }
        return _mapper.Map<GetDoctorDto>(doctor);
    }

    public async Task<PostDoctorDto> CreateDoctor(PostDoctorDto doctorDto)
    {
        var doctor = _mapper.Map<Doctor>(doctorDto);
        var result = await _doctorRepository.CreateDoctor(doctor);
        return _mapper.Map<PostDoctorDto>(result);
    }

    public async Task<PutDoctorDto> UpdateDoctor(PutDoctorDto doctorDto)
    {
        var doctor = _mapper.Map<Doctor>(doctorDto);
        var result = await _doctorRepository.UpdateDoctor(doctor);
        return _mapper.Map<PutDoctorDto>(result);
    }

    public async Task DeleteDoctor(int id)
    {
        var doctor = await _doctorRepository.GetDoctorById(id);
        await _doctorRepository.DeleteDoctor(doctor);
    }
}
