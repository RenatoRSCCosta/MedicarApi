using Medicar_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Domain.Interfaces;

public interface ISlotRepository
{
    Task<List<Slot>> GetAllSlots();
    Task<Slot> GetSlotById(int id);
    Task<Slot> CreateSlot(Slot slot);
    Task<Slot> UpdateSlot(Slot slot);
    Task DeleteSlot(Slot slot);
}