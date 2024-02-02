using Medicar.Application.Dtos.ScheduleDtos;
using Medicar.Domain.Return;

namespace Medicar.Application.Interfaces;

public interface IScheduleService
{
    Task<CustomReturn<ScheduleDto>> GetAll();
    Task<CustomReturn<ScheduleDto>> Add(PostScheduleDto schedule);

}
