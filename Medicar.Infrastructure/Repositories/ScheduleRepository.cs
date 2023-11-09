using Medicar.Domain.Interfaces;
using Medicar.Infrastructure.Contexs;
using Medicar_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Medicar.Infrastructure.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ScheduleRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Schedule> CreateSchedule (Schedule schedule)
    {
        _dbContext.Schedules.Add(schedule);
        await _dbContext.SaveChangesAsync();
        return schedule;
    }

    public async Task DeleteSchedule(Schedule schedule)
    {
        _dbContext.Schedules.Remove(schedule);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Schedule>> GetAllSchedules()
    {
        return await _dbContext.Schedules.ToListAsync();
    }

    public async Task<Schedule> GetScheduleById(int id)
    {
        return await _dbContext.Schedules.FindAsync(id);
    }

    public async Task<Schedule> UpdateSchedule(Schedule schedule)
    {
        _dbContext.Schedules.Update(schedule);
        await _dbContext.SaveChangesAsync();
        return await GetScheduleById(schedule.ScheduleId);
    }

    public async Task<Schedule> GetScheduleByDoctorAndDate(int doctorId, DateTime date)
    {
        return await _dbContext.Schedules.Where(s => s.DoctorId == doctorId && s.Date == date).FirstOrDefaultAsync();
    }
}
