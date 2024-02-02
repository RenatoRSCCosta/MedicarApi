using Medicar.Application.Dtos.SlotDtos;
using Medicar.Domain.Return;

namespace Medicar.Application.Interfaces;

public interface ISlotService
{
    Task<CustomReturn<SlotDto>> GetSlotsBySchedule(int scheduleId);
    Task<CustomReturn<SlotDto>> GetById(int id);
    Task<CustomReturn<SlotDto>> Add(PostSlotDto slotDto);
    Task<CustomReturn<SlotDto>> Update(SlotDto slotDto);
    Task<CustomReturn<SlotDto>> Delete(int id);

}
