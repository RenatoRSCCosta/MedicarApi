using Medicar.Application.Dtos;
using Medicar.Application.Dtos.GetDtos;
using Medicar.Application.Dtos.PostDtos;
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
    public async Task<ActionResult<List<GetDoctorDto>>> GetAll()
    {
        var doctors = await _doctorService.GetAllDoctors();
        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<GetDoctorDto>>> GetById(int id)
    {
        var doctor = await _doctorService.GetDoctorById(id);
        if (doctor is not null)
        {
            return Ok(doctor);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<PostDoctorDto>> Add(PostDoctorDto doctorDto)
    {
        var doctor = await _doctorService.CreateDoctor(doctorDto);
        if (doctor is not null)
        {
            return Ok(doctor);
        }
        return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PutDoctorDto>> Update(int id, PutDoctorDto doctorDto)
    {
        var doctor = await _doctorService.UpdateDoctor(doctorDto);
        if (doctor is not null)
        {
            return Ok(doctor);
        }
        return BadRequest();
    }

}
