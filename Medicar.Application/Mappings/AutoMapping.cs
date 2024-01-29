using AutoMapper;
using Medicar.Application.Dtos.DoctorDtos;
using Medicar.Application.Dtos.ScheduleDtos;
using Medicar.Application.Dtos.SpecialtyDtos;
using Medicar_API.Domain.Entities;

namespace Medicar.Application.Mappings;

public class AutoMapping : Profile
{
    public AutoMapping() 
    {
        #region Doctor Map
        CreateMap<Doctor, PostDoctorDto>().ReverseMap();
        CreateMap<Doctor, DoctorDto>().ReverseMap();
        #endregion

        #region Specialty Map
        CreateMap<Specialty, PostSpecialtyDto>().ReverseMap();
        CreateMap<Specialty, SpecialtyDto>().ReverseMap();
        #endregion

        #region Schedule Map
        CreateMap<Schedule, PostScheduleDto>().ReverseMap();
        #endregion

        #region Slot Map
        CreateMap<PostSlotDto, Slot>()
            .ForMember(dest => dest.Hour, opt => opt.MapFrom(src => DateConvertHelper.ConvertHourToDouble(src.Hour)));
        CreateMap<Slot, PostSlotDto>()
            .ForMember(dest => dest.Hour, opt => opt.MapFrom(src => DateConvertHelper.ConvertDoubleToHour(src.Hour)));
        //CreateMap<Specialty, PutSlotDto>().ReverseMap();
        CreateMap<Slot, GetSlotDto>().ForMember(dest => dest.Hour, opt => opt.MapFrom(src => DateConvertHelper.ConvertDoubleToHour(src.Hour))).ReverseMap();
        #endregion
    }
}
