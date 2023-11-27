using Medicar.Application.Dtos.PostDtos;
using Medicar.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ScheduleController : ControllerBase
{

    private readonly IScheduleService _scheduleService;

    public ScheduleController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpPost]
    public async Task<ActionResult> Add(PostScheduleDto scheduleDto)
    {
        var schedule = await _scheduleService.CreateSchedule(scheduleDto);

        if (schedule is not null)
        {
            return Ok(schedule);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var schedule = await _scheduleService.GetAllSchedules();

        if (schedule is not null)
        {
            return Ok(schedule);
        }
        else
        {
            return BadRequest();
        }
    }

}
