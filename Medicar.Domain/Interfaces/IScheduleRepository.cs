using Medicar_API.Domain.Entities;

namespace Medicar.Domain.Interfaces;

public interface IScheduleRepository
{
    Task<List<Schedule>> GetAll();

    Task<Schedule?> GetById(int id);

    Task<Schedule?> Add(Schedule schedule);

    Task<Schedule?> Update(Schedule schedule);

    Task Delete(Schedule schedule);

    Task<bool> CheckScheduleForDay(int doctorId, DateTime date);
}
