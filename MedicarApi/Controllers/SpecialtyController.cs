using Medicar.Application.Dtos;
using Medicar.Application.Dtos.SpecialtyDtos;
using Medicar.Application.Interfaces;
using Medicar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class SpecialtyController : ControllerBase
{
    private readonly ISpecialtyService _specialtyService;

    public SpecialtyController(ISpecialtyService specialtyService)
    {
        _specialtyService = specialtyService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var specialtys = await _specialtyService.GetAllSpecialtys();
        return Ok(specialtys);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var specialty = await _specialtyService.GetSpecialtyById(id);
        if (specialty is not null)
        {
            return Ok(specialty);
        }
        return NotFound();

    }

    [HttpPost]
    public async Task<ActionResult> Add(PostSpecialtyDto specialtyDto)
    {
        var specialty = await _specialtyService.CreateSpecialty(specialtyDto);
        if (specialty is not null)
        {
            return Ok(specialty);
        }
        return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, SpecialtyDto specialtyDto)
    {
        var specialty = await _specialtyService.UpdateSpecialty(specialtyDto);
        if (specialty is not null)
        {
            return Ok(specialty);
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var specialty = await _specialtyService.DeleteSpecialtyById(id);

        if (specialty is not null)
        {
            return Ok(specialty);
        }

        return BadRequest();
    }

}
