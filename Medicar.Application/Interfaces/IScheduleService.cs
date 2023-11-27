using Medicar.Application.Dtos.GetDtos;
using Medicar.Application.Dtos.PostDtos;
using Medicar.Domain.Return;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Interfaces;

public interface IScheduleService
{
    Task<CustomReturn<PostScheduleDto>> CreateSchedule(PostScheduleDto schedule);
    Task<CustomReturn<GetScheduleDto>> GetAllSchedules();
}
