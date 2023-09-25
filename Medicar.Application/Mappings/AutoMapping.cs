using AutoMapper;
using Medicar.Application.Dtos;
using Medicar.Application.Dtos.GetDtos;
using Medicar.Application.Dtos.PostDtos;
using Medicar_API.Domain.Entities;

namespace Medicar.Application.Mappings;

public class AutoMapping : Profile
{
    public AutoMapping() 
    {
        CreateMap<Doctor, DoctorDto>().ReverseMap();
        CreateMap<Specialty, PostSpecialtyDto>().ReverseMap();
        CreateMap<Specialty, PutSpecialtyDto>().ReverseMap();
        CreateMap<Specialty, GetSpecialtyDto>().ReverseMap();
    }
}
