using Medicar_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Domain.Interfaces;

public interface IScheduleRepository
{
    Task<List<Schedule>> GetAllSchedules();
    Task<Schedule> GetScheduleById(int id);
    Task<Schedule> CreateSchedule(Schedule schedule);
    Task<Schedule> UpdateSchedule(Schedule schedule);
    Task DeleteSchedule(Schedule schedule);
    Task<Schedule> GetScheduleByDoctorAndDate(int doctorId, DateTime date);
}
