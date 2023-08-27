using Medicar.Application.Dtos;
using Medicar.Application.Interfaces;
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
    public async Task<ActionResult<List<SpecialtyDto>>> GetAll()
    {
        var specialtys = await _specialtyService.GetAllSpecialtys();
        return Ok(specialtys);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<SpecialtyDto>>> GetById(int id)
    {
        var specialty = await _specialtyService.GetSpecialtyById(id);
        if (specialty is not null)
        {
            return Ok(specialty);
        }
        return NotFound();

    }

    [HttpPost]
    public async Task<ActionResult<SpecialtyDto>> Add(SpecialtyDto specialtyDto)
    {
        var specialty = await _specialtyService.CreateSpecialty(specialtyDto);
        if (specialty is not null)
        {
            return Ok(specialty);
        }
        return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SpecialtyDto>> Update(int id, SpecialtyDto specialtyDto)
    {
        var specialty = _specialtyService.UpdateSpecialty(specialtyDto);
        if (specialty is not null)
        {
            return Ok(specialty);
        }
        return BadRequest();
    }

}
