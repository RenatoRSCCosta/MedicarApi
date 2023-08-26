using AutoMapper;
using Medicar.Application.Dtos;
using Medicar_API.Domain.Entities;

namespace Medicar.Application.Mappings;

public class AutoMapping : Profile
{
    public AutoMapping() 
    {
        CreateMap<Doctor, DoctorDto>().ReverseMap();
        CreateMap<Specialty, SpecialtyDto>().ReverseMap();
    }
}
