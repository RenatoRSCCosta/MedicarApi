using Medicar.Application.Dtos;
using Medicar.Application.Dtos.DoctorDtos;
using Medicar.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var doctors = await _doctorService.GetAllDoctors();

        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var doctor = await _doctorService.GetDoctorById(id);

        if (doctor is not null)
        {
            return Ok(doctor);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> Add(PostDoctorDto doctorDto)
    {
        var doctor = await _doctorService.CreateDoctor(doctorDto);

        if (doctor is not null)
        {
            return Ok(doctor);
        }

        return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, DoctorDto doctorDto)
    {
        var doctor = await _doctorService.UpdateDoctor(doctorDto);

        if (doctor is not null)
        {
            return Ok(doctor);
        }

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var doctor = await _doctorService.DeleteDoctor(id);

        if (doctor is not null)
        {
            return Ok(doctor);
        }

        return BadRequest();
    }

}
