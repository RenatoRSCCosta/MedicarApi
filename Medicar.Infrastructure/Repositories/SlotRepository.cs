using Medicar.Domain.Interfaces;
using Medicar.Infrastructure.Contexs;
using Medicar_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medicar.Infrastructure.Repositories;

public class SlotRepository : ISlotRepository
{
    private readonly ApplicationDbContext _dbContext;
    public SlotRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<Slot>> GetSlotsByScheduleId(int scheduleId)
    {
        return await _dbContext.Slots
            .Where(s => s.Id == scheduleId)
            .ToListAsync();
    }

    public async Task<Slot?> GetById(int id)
    {
        return await _dbContext.Slots.FindAsync(id);
    }

    public async Task<Slot?> Add(Slot slot)
    {
        _dbContext.Slots.Add(slot);

        await _dbContext.SaveChangesAsync();

        return await GetById(slot.Id);
    }

    public async Task Delete(Slot slot)
    {
        _dbContext.Slots.Remove(slot);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<Slot?> Update(Slot slot)
    {
        _dbContext.Slots.Update(slot);

        await _dbContext.SaveChangesAsync();

        return await GetById(slot.Id);
    }
}
