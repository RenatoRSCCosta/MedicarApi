using Medicar_API.Domain.Entities;

namespace Medicar.Domain.Interfaces;

public interface ISlotRepository
{
    Task<List<Slot>> GetAll();

    Task<Slot?> GetById(int id);

    Task<Slot?> Add(Slot slot);

    Task<Slot?> Update(Slot slot);

    Task Delete(Slot slot);
}