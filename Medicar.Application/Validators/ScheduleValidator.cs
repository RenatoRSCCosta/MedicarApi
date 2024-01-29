using FluentValidation;
using Medicar.Application.Dtos.ScheduleDtos;
using Medicar.Domain.Interfaces;
using Medicar_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Validators;

public class ScheduleValidator : AbstractValidator<PostScheduleDto>
{
    IScheduleRepository _scheduleRepository;
    public ScheduleValidator(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;

        RuleFor(schedule => schedule.Date).GreaterThan(DateTime.Now.Date)
            .WithMessage("Não é possivel criar agenda para um dia passado");

        RuleFor(schedule => schedule).MustAsync(async (schedule, cancellation) =>
        {
            return !await _scheduleRepository.CheckScheduleForDay(schedule.DoctorId,schedule.Date);
        })
            .WithMessage("Não é possivel criar mais de uma agenda para o medico no mesmo dia");
    }
}

