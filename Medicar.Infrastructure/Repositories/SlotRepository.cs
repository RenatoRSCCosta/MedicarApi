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

    public async Task<Slot> CreateSlot(Slot slot)
    {
        _dbContext.Slots.Add(slot);
        await _dbContext.SaveChangesAsync();
        return slot;
    }

    public async Task DeleteSlot(Slot slot)
    {
        _dbContext.Slots.Remove(slot);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Slot>> GetAllSlots()
    {
        return await _dbContext.Slots.ToListAsync();
    }

    public async Task<Slot> GetSlotById(int id)
    {
        return await _dbContext.Slots.FindAsync(id);
    }

    public async Task<Slot> UpdateSlot(Slot slot)
    {
        _dbContext.Slots.Update(slot);
        await _dbContext.SaveChangesAsync();
        return await GetSlotById(slot.SlotId);
    }
}
