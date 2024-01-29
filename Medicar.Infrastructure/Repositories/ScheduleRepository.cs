using Medicar.Domain.Interfaces;
using Medicar.Infrastructure.Contexs;
using Medicar_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medicar.Infrastructure.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ScheduleRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<Schedule>> GetAll()
    {
        return await _dbContext.Schedules
            .AsNoTracking()
            .Include(s => s.Slots)
            .Include(s => s.Doctor)
            .ThenInclude(d => d.Specialty)
            .Where(s => s.Date >= DateTime.Now.Date)
            .ToListAsync();
    }

    public async Task<Schedule?> GetById(int id)
    {
        return await _dbContext.Schedules
            .AsNoTracking()
            .Include(s => s.Slots)
            .Include(s => s.Doctor)
            .ThenInclude(d => d.Specialty)
            .FirstOrDefaultAsync(s => s.ScheduleId == id);
    }

    public async Task<Schedule?> Add(Schedule schedule)
    {
        _dbContext.Schedules.Add(schedule);

        await _dbContext.SaveChangesAsync();

        return await GetById(schedule.ScheduleId);
    }

    public async Task<Schedule?> Update(Schedule schedule)
    {
        _dbContext.Schedules.Update(schedule);

        await _dbContext.SaveChangesAsync();

        return await GetById(schedule.ScheduleId);
    }

    public async Task Delete(Schedule schedule)
    {
        _dbContext.Schedules.Remove(schedule);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> CheckScheduleForDay(int doctorId, DateTime date)
    {
        return await _dbContext.Schedules
            .Where(s => s.DoctorId == doctorId && s.Date == date)
            .AnyAsync();
    }
}
