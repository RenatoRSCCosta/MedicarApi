using Medicar.Application.Dtos;
using Medicar.Application.Dtos.GetDtos;
using Medicar.Application.Dtos.PostDtos;
using Medicar.Application.Dtos.PutDtos;
using Medicar.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class SlotController : ControllerBase
{
    private readonly ISlotService _slotService;

    public SlotController(ISlotService slotService)
    {
        _slotService = slotService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var slots = await _slotService.GetAllSlots();

        return Ok(slots);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var slot = await _slotService.GetSlotById(id);

        if (slot is not null)
        {
            return Ok(slot);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> Add(PostSlotDto slotDto)
    {
        var slot = await _slotService.CreateSlot(slotDto);

        if (slot is not null)
        {
            return Ok(slot);
        }

        return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, PutSlotDto slotDto)
    {
        var slot = await _slotService.UpdateSlot(slotDto);

        if (slot is not null)
        {
            return Ok(slot);
        }

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var slot = await _slotService.DeleteSlot(id);

        if (slot is not null)
        {
            return Ok(slot);
        }

        return BadRequest();
    }

}
