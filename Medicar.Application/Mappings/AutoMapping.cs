using AutoMapper;
using Medicar.Application.Dtos.GetDtos;
using Medicar.Application.Dtos.PostDtos;
using Medicar_API.Domain.Entities;

namespace Medicar.Application.Mappings;

public class AutoMapping : Profile
{
    public AutoMapping() 
    {
        #region Doctor Map
        CreateMap<Doctor, PostDoctorDto>().ReverseMap();
        CreateMap<Doctor, PutDoctorDto>().ReverseMap();
        CreateMap<Doctor, GetDoctorDto>().ReverseMap();
        #endregion

        #region Specialty Map
        CreateMap<Specialty, PostSpecialtyDto>().ReverseMap();
        CreateMap<Specialty, PutSpecialtyDto>().ReverseMap();
        CreateMap<Specialty, GetSpecialtyDto>().ReverseMap();
        #endregion
    }
}
